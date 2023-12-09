namespace Infrastructure.StateMachineForGame
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}