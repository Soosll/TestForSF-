using EnemyLogic.SpawnLogic;
using HeroLogic;
using Infrastructure.AssetManagement;
using Infrastructure.Factories.ForHero;
using Infrastructure.General;
using Infrastructure.Handlers.HeroHandler;
using UI;
using UI.Hero;
using UnityEngine;

namespace Infrastructure.StateMachineForGame.States
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string HeroSpawnPointTag = "SpawnPoint";
        private const string EnemySpawnerTag = "EnemySpawner";

        private readonly GameStateMachine _gameStateMachine;

        private readonly ISceneLoader _sceneLoader;
        private readonly IHeroFactory _heroFactory;
        private readonly IAssetProvider _assetProvider;
        private readonly IHeroHandler _heroHandler;

        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IHeroFactory heroFactory,
            IAssetProvider assetProvider, IHeroHandler heroHandler)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _heroFactory = heroFactory;
            _assetProvider = assetProvider;
            _heroHandler = heroHandler;
        }

        public void Enter(string payLoad)
        {
            _sceneLoader.LoadScene(payLoad, InitGameWorld);
        }

        public void Exit()
        {
        }

        private void InitGameWorld()
        {
            SpawnHero();
            RunEnemiesSpawnLogic();
            SpawnHeroHUD();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void SpawnHeroHUD()
        {
            var heroHUDGameObject = _assetProvider.Instantiate(AssetPath.HeroHUDPath);
            var heroHUD = heroHUDGameObject.GetComponent<HeroHUD>();

            var heroHealth = _heroHandler.Hero.GetComponent<HeroHealth>();
            var heroAttacker = _heroHandler.Hero.GetComponent<HeroAttacker>();

            heroHUD.InitComponents(heroHealth, heroAttacker);
        }

        private void SpawnHero() =>
            _heroFactory.CreateHero(GameObject.FindWithTag(HeroSpawnPointTag).transform);

        private void RunEnemiesSpawnLogic()
        {
            var spawnerGameObject = GameObject.FindWithTag(EnemySpawnerTag);
            spawnerGameObject.GetComponent<EnemySpawner>().RunSpawnLogic();
        }
    }
}