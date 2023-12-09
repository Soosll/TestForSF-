using Infrastructure.StateMachineForGame;
using Infrastructure.StateMachineForGame.States;

namespace Infrastructure.General
{
    public class Game : IGame
    {
        private readonly GameStateMachine _stateMachine;
        private readonly BootstrapState _bootstrapState;
        private readonly LoadLevelState _loadLevelState;
        private readonly GameLoopState _gameLoopState;
        private readonly UnloadState _unloadState;

        public Game(GameStateMachine stateMachine, BootstrapState bootstrapState, LoadLevelState loadLevelState, GameLoopState gameLoopState, UnloadState unloadState)
        {
            _stateMachine = stateMachine;
            _bootstrapState = bootstrapState;
            _loadLevelState = loadLevelState;
            _gameLoopState = gameLoopState;
            _unloadState = unloadState;
        }

        public void InitStateMachine() => 
            _stateMachine.InitStates(_bootstrapState, _loadLevelState, _gameLoopState, _unloadState);

        public void RunStateMachine() => 
            _stateMachine.Enter<BootstrapState>();
    }
}