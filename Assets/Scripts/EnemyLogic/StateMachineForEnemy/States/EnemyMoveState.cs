using HeroLogic;
using UnityEngine;

namespace EnemyLogic.StateMachineForEnemy.States
{
    public class EnemyMoveState : EnemyState
    {
        private readonly Transform _enemy;
        private readonly Rigidbody2D _rigidbody;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly Transform _target;

        private readonly float _speed;

        private readonly IFlipper _flipper;

        public EnemyMoveState(Transform enemy, Rigidbody2D rigidbody, EnemyAnimator enemyAnimator, Transform target,
            IFlipper flipper, float speed)
        {
            _enemy = enemy;
            _rigidbody = rigidbody;
            _enemyAnimator = enemyAnimator;
            _target = target;
            _speed = speed;
            _flipper = flipper;
        }

        public override void Enter()
        {
            _enemyAnimator.PlayWalk();
        }

        public override void FixedUpdate()
        {
            var direction = (_target.transform.position - _enemy.transform.position).normalized;

            TryToFlip(direction);

            _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        }

        public override void Exit()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        private void TryToFlip(Vector3 direction)
        {
            if (direction.x > 0)
                _flipper.FlipRight();
            else
                _flipper.FlipLeft();
        }
    }
}