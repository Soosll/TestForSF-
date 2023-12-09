using Services.ForDispose;
using Services.ForInput;

namespace Infrastructure.StateMachineForGame.States
{
    public class UnloadState : IState
    {
        private readonly IDisposeService _disposeService;
        private readonly IInputService _inputService;

        public UnloadState(IDisposeService disposeService, IInputService inputService)
        {
            _disposeService = disposeService;
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.IsActive = true;
            _disposeService.Dispose();
        }

        public void Exit()
        {
        }
    }
}