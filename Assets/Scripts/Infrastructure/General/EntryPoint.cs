using Infrastructure.Handlers.CoroutineHandler;
using UnityEngine;
using Zenject;

namespace Infrastructure.General
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private IGame _game;
        private ICoroutineRunnerHandler _coroutineRunnerHandler;

        [Inject]
        public void Construct(IGame game, ICoroutineRunnerHandler coroutineRunnerHandler)
        {
            _game = game;
            _coroutineRunnerHandler = coroutineRunnerHandler;

            _coroutineRunnerHandler.CoroutineRunner = this;
        }
    
        private void Awake()
        {
            _game.InitStateMachine();
            _game.RunStateMachine();
        
            DontDestroyOnLoad(this);
        }
    }
}
