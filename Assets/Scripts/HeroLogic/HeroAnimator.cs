using UnityEngine;

namespace HeroLogic
{
    public class HeroAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        [SerializeField] private string AttackTriggerName;
        [SerializeField] private string DeathTriggerName;
        
        public void PlayAttack() => 
            _animator.SetTrigger(AttackTriggerName);

        public void PlayDeath() => 
            _animator.SetTrigger(DeathTriggerName);
    }
}