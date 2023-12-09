using Infrastructure.StateMachineForGame;
using Infrastructure.StateMachineForGame.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI.Buttons
{
    public class RestartButton : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        private string _currentSceneName;
        
        [Inject]
        public void Construct(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake() => 
            _currentSceneName = SceneManager.GetActiveScene().name;

        public void Restart() => 
            _gameStateMachine.Enter<LoadLevelState, string>(_currentSceneName);
    }
}