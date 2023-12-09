using System.Collections;
using HeroLogic;
using Infrastructure.General;
using UnityEngine;

namespace EnemyLogic.StateMachineForEnemy.States
{
    public class EnemyAttackState : EnemyState
    {
        private readonly EnemyAnimator _enemyAnimator;
        private readonly AttackCollider _attackCollider;

        private readonly int _damage;
        private readonly float _attackCoolDown;

        private bool _canAttack = true;
        
        private readonly ICoroutineRunner _coroutineRunner;

        public EnemyAttackState(EnemyAnimator enemyAnimator, AttackCollider attackCollider, ICoroutineRunner coroutineRunner, int damage, float attackCoolDown)
        {
            _enemyAnimator = enemyAnimator;
            _attackCollider = attackCollider;
            _coroutineRunner = coroutineRunner;
            _damage = damage;
            _attackCoolDown = attackCoolDown;

            Subscribe();
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
            if(_canAttack)
                Attack();
        }

        private void Attack()
        {
            _canAttack = false;
            _enemyAnimator.PlayAttack();
            _coroutineRunner.StartCoroutine(CoolDownTimer(_attackCoolDown));
        }

        private IEnumerator CoolDownTimer(float coolDownTime)
        {
            yield return new WaitForSeconds(coolDownTime);
            _canAttack = true;
        }

        private void Subscribe() => 
            _attackCollider.OnTriggerFound += CheckHero;

        private void CheckHero(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out HeroHealth heroHealth))
                heroHealth.TakeDamage(_damage);
        }
    }
}