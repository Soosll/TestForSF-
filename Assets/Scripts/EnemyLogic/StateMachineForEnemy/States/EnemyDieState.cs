using Infrastructure.General;
using UnityEngine;

namespace EnemyLogic.StateMachineForEnemy.States
{
    public class EnemyDieState : EnemyState
    {
        private readonly Transform _enemy;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly EnemyTargetDistanceChecker _distanceChecker;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly float _destroyTime;

        private bool _needDestroy;

        private float _runningTime;
        
        public EnemyDieState(Transform enemy, Rigidbody2D rigidbody2D, EnemyAnimator enemyAnimator,
            ICoroutineRunner coroutineRunner, float destroyTime)
        {
            _enemy = enemy;
            _rigidbody2D = rigidbody2D;
            _enemyAnimator = enemyAnimator;
            _coroutineRunner = coroutineRunner;
            _destroyTime = destroyTime;
        }

        public override void Enter()
        {
            _runningTime = _destroyTime;
            
            _enemyAnimator.PlayDie();
            _rigidbody2D.isKinematic = true;

            _needDestroy = true;
        }

        public override void Update()
        {
            if(!_needDestroy)
                return;

            _runningTime -= Time.deltaTime;

            if (_runningTime <= 0)
                Object.Destroy(_enemy.gameObject);
        }
    }
}