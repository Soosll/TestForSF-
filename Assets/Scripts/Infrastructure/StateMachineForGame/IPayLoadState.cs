namespace Infrastructure.StateMachineForGame
{
    public interface IPayLoadState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}