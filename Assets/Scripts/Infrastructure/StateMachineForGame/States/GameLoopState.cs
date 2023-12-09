using System.Collections;
using HeroLogic;
using Infrastructure.AssetManagement;
using Infrastructure.Handlers.CoroutineHandler;
using Infrastructure.Handlers.HeroHandler;
using UnityEngine;

namespace Infrastructure.StateMachineForGame.States
{
    public class GameLoopState : IState
    {
        private const float TimeBeforeShowLoseUI = 2f;

        private HeroHealth _heroHealth;

        private readonly GameStateMachine _stateMachine;
        private readonly IHeroHandler _heroHandler;
        private readonly ICoroutineRunnerHandler _coroutineRunnerHandler;
        private readonly IAssetProvider _assetProvider;

        public GameLoopState(GameStateMachine stateMachine, IHeroHandler heroHandler,
            ICoroutineRunnerHandler coroutineRunnerHandler, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
            _heroHandler = heroHandler;
            _coroutineRunnerHandler = coroutineRunnerHandler;
            _assetProvider = assetProvider;
        }

        public void Enter()
        {
            _heroHealth = _heroHandler.Hero.GetComponent<HeroHealth>();

            Subscribe();
        }

        public void Exit()
        {
           // CleanUp();
        }

        private void ShowLoseUI() =>
            _coroutineRunnerHandler.CoroutineRunner.StartCoroutine(LoseUITimer());

        private void Subscribe() =>
            _heroHealth.OnHealthIsOver += ShowLoseUI;

        private void CleanUp() =>
            _heroHealth.OnHealthIsOver -= ShowLoseUI;

        private IEnumerator LoseUITimer()
        {
            yield return new WaitForSeconds(TimeBeforeShowLoseUI);

            _assetProvider.Instantiate(AssetPath.LoseUIPath);
            _stateMachine.Enter<UnloadState>();
        }
    }
}