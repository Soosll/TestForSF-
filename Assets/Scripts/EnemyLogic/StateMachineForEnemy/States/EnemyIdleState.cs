namespace EnemyLogic.StateMachineForEnemy.States
{
    public class EnemyIdleState : EnemyState
    {
        private readonly EnemyAnimator _enemyAnimator;

        public EnemyIdleState(EnemyAnimator enemyAnimator)
        {
            _enemyAnimator = enemyAnimator;
        }
        
        public override void Enter()
        {
            _enemyAnimator.PlayIdle();
        }
    }
}