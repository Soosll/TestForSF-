using System;
using EnemyLogic.StateMachineForEnemy;
using EnemyLogic.StateMachineForEnemy.States;
using HeroLogic;
using Infrastructure.General;
using UnityEngine;

namespace EnemyLogic
{
    public class Enemy : MonoBehaviour, IAttackColliderActivator
    {
        private EnemyStateMachine _stateMachine;
        private EnemyTargetDistanceChecker _distanceChecker;
        private AttackCollider _attackCollider;

        private bool _isDie;

        private void Start() =>
            RunEnemyLogic();

        private void Update()
        {
            _stateMachine.CurrentState.Update();

            if (_isDie)
                return;
            
            if (_distanceChecker.CheckDistance())
                _stateMachine.Enter<EnemyAttackState>();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.FixedUpdate();
        }

        public void InitEnemyComponents(EnemyStateMachine stateMachine,
            EnemyTargetDistanceChecker enemyTargetDistanceChecker, AttackCollider attackCollider)
        {
            _stateMachine = stateMachine;
            _distanceChecker = enemyTargetDistanceChecker;
            _attackCollider = attackCollider;
        }

        private void RunEnemyLogic() => 
            _stateMachine.Enter<EnemyMoveState>();

        public void ActivateAttackCollider() =>
            _attackCollider.Enable();

        public void DiactivateAttackCollider() =>
            _attackCollider.Disable();

        public void Die()
        {
            _isDie = true;
            _stateMachine.Enter<EnemyDieState>();
        }
    }
}