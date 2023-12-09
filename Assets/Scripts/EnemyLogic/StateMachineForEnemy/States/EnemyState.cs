namespace EnemyLogic.StateMachineForEnemy.States
{
    public abstract class EnemyState
    {
        public abstract void Enter();

        public virtual void Exit()
        {}

        public virtual void Update()
        {}

        public virtual void FixedUpdate()
        {}
    }
}