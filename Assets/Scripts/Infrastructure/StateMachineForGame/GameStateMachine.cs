using System;
using System.Collections.Generic;
using Infrastructure.StateMachineForGame.States;

namespace Infrastructure.StateMachineForGame
{
    public class GameStateMachine
    {
        private IExitableState _currentState;

        private Dictionary<Type, IExitableState> _states;

        public void InitStates(BootstrapState bootstrapState, LoadLevelState loadLevelState, GameLoopState gameLoopState, UnloadState unloadState)
        {
            _states = new Dictionary<Type, IExitableState>();
            
            _states.Add(typeof(BootstrapState), bootstrapState);
            _states.Add(typeof(LoadLevelState), loadLevelState);
            _states.Add(typeof(GameLoopState), gameLoopState);
            _states.Add(typeof(UnloadState), unloadState);
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            
            TState state = _states[typeof(TState)] as TState;

            _currentState = state;
            
            return state;
        }
    }
}