using System;
using System.Collections.Generic;
using EnemyLogic.StateMachineForEnemy.States;
using HeroLogic;
using Infrastructure.General;
using StaticData.ForEnemy;
using UnityEngine;

namespace EnemyLogic.StateMachineForEnemy
{
    public class EnemyStateMachine
    {
        private Dictionary<Type, EnemyState> _states;

        private readonly Transform _enemy;
        private readonly Rigidbody2D _rigidbody;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly Hero _target;
        private readonly AttackCollider _attackCollider;
        private readonly EnemyTargetDistanceChecker _distanceChecker;
        
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IFlipper _flipper;

        public EnemyState CurrentState { get; private set; }

        public EnemyStateMachine(Transform enemy, Rigidbody2D rigidbody, EnemyAnimator enemyAnimator, Hero target, AttackCollider attackCollider, ICoroutineRunner coroutineRunner, IFlipper flipper)
        {
            _enemy = enemy;
            _rigidbody = rigidbody;
            _enemyAnimator = enemyAnimator;
            _target = target;
            _attackCollider = attackCollider;
            _coroutineRunner = coroutineRunner;
            _flipper = flipper;
        }

        public void InitStates(EnemyStaticData staticData)
        {
            _states = new Dictionary<Type, EnemyState>()
            {
                [typeof(EnemyIdleState)] = new EnemyIdleState(_enemyAnimator),
                [typeof(EnemyMoveState)] = new EnemyMoveState(_enemy, _rigidbody, _enemyAnimator, _target.transform, _flipper, staticData.Speed),
                [typeof(EnemyAttackState)] = new EnemyAttackState(_enemyAnimator, _attackCollider, _coroutineRunner, staticData.Damage, staticData.AttackCoolDown),
                [typeof(EnemyDieState)] = new EnemyDieState(_enemy, _rigidbody, _enemyAnimator, _coroutineRunner, staticData.DestroyTime),
            };
        }
        
        public void Enter<TState>() where TState : EnemyState
        {
            CurrentState?.Exit();

            var state = _states[typeof(TState)];

            CurrentState = state;
            
            state.Enter();
        }
    }
}