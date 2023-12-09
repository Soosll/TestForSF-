using UnityEngine;

namespace EnemyLogic
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const float TransitionDuration = 0.1f;
        
        [SerializeField] private Animator _animator;

        [Space(25)]
        [Header("Animation Names")]
        [SerializeField] private string _walkAnimationName;
        [SerializeField] private string _attackAnimationName;
        [SerializeField] private string _dieAnimationName;
        [SerializeField] private string _idleAnimationName;

        public void PlayWalk() => 
            PlayCrossFadeAnimation(_walkAnimationName);

        public void PlayAttack() => 
            PlayCrossFadeAnimation(_attackAnimationName);

        public void PlayIdle() => 
            PlayCrossFadeAnimation(_idleAnimationName);

        public void PlayDie() => 
            PlayCrossFadeAnimation(_dieAnimationName);

        private void PlayCrossFadeAnimation(string triggerName) => 
            _animator.CrossFade(triggerName, TransitionDuration);
    }
}