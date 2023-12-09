using EnemyLogic;
using EnemyLogic.StateMachineForEnemy;
using HeroLogic;
using Infrastructure.Handlers.CoroutineHandler;
using Infrastructure.Handlers.HeroHandler;
using Services.ForStaticData.ForEnemy;
using StaticData.ForEnemy;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories.ForEnemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IEnemyStaticDataService _enemyStaticDataService;
        private readonly IInstantiator _instantiator;
        private readonly IHeroHandler _heroHandler;
        private readonly ICoroutineRunnerHandler _coroutineRunnerHandler;

        public EnemyFactory(IEnemyStaticDataService enemyStaticDataService, IInstantiator instantiator, IHeroHandler heroHandler, ICoroutineRunnerHandler coroutineRunnerHandler)
        {
            _enemyStaticDataService = enemyStaticDataService;
            _instantiator = instantiator;
            _heroHandler = heroHandler;
            _coroutineRunnerHandler = coroutineRunnerHandler;
        }
        
        public Enemy CreateEnemy(EnemyTypeID enemyID, Transform parent)
        {
            EnemyStaticData staticData = _enemyStaticDataService.ForEnemy(enemyID);

            var spawnedEnemy =_instantiator.InstantiatePrefab(staticData.Prefab, parent.transform.position, Quaternion.identity, parent);

            var enemy = spawnedEnemy.GetComponent<Enemy>();

            var enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
            var enemyAnimator = enemy.GetComponent<EnemyAnimator>();

            var coroutineRunner = _coroutineRunnerHandler.CoroutineRunner;
            
            EnemyTargetDistanceChecker distanceChecker = new EnemyTargetDistanceChecker(enemy.transform, _heroHandler.Hero, staticData.DistanceBeforeAttack);

            var enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();

            IFlipper enemyFlipper = new EnemyFlipper(enemySpriteRenderer); 
            
            var enemyAttackCollider = enemy.GetComponentInChildren<AttackCollider>();
            enemyAttackCollider.InitFlipper(enemyFlipper);
            enemyAttackCollider.Disable();
            
            EnemyStateMachine stateMachine = new EnemyStateMachine(spawnedEnemy.transform, enemyRigidbody, enemyAnimator, _heroHandler.Hero, enemyAttackCollider, coroutineRunner, enemyFlipper);
            stateMachine.InitStates(staticData);

            enemy.InitEnemyComponents(stateMachine, distanceChecker, enemyAttackCollider);
            return enemy;
        }
    }
}