using System;
using EnemyLogic;
using Infrastructure.General;
using Services.ForInput;
using UnityEngine;

namespace HeroLogic
{
    public class HeroAttacker : MonoBehaviour, IAttackColliderActivator
    {
        private HeroAnimator _heroAnimator;
        private AttackCollider _attackCollider;

        private IInputService _inputService;

        private int _killedEnemyCount;
        
        private bool _canAttack = true;

        public event Action<int> OnKilledEnemy;
        
        private void Awake() => 
            _heroAnimator = GetComponent<HeroAnimator>();

        public void InitComponents(AttackCollider attackCollider, IInputService inputService)
        {
            _attackCollider = attackCollider;
            _inputService = inputService;
            
            Subscribe();
        }

        public void ActivateAttackCollider() => 
            _attackCollider.Enable();

        public void DiactivateAttackCollider() =>
            _attackCollider.Disable();

        public void SetAttackIsReady() => 
            _canAttack = true;

        private void RunAttackCooldown() => 
            _canAttack = false;

        private void Attack()
        {
            if (!_canAttack)
                return;

            RunAttackCooldown();
            _heroAnimator.PlayAttack();
        }
        
        private void Subscribe()
        {
            _inputService.OnInputRightArrow += Attack;
            _inputService.OnInputLeftArrow += Attack;
            _attackCollider.OnTriggerFound += CheckEnemy;
        }

        private void CheckEnemy(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
                
                _killedEnemyCount++;
                
                OnKilledEnemy?.Invoke(_killedEnemyCount);
            }
        }

        private void CleanUp()
        {
            _inputService.OnInputRightArrow -= Attack;
            _inputService.OnInputLeftArrow -= Attack;
            _attackCollider.OnTriggerFound -= CheckEnemy;
        }

        private void OnDisable()
        {
            CleanUp();
        }
    }
}