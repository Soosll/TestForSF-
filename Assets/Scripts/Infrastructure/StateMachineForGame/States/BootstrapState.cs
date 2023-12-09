using Services.ForStaticData.ForEnemy;

namespace Infrastructure.StateMachineForGame.States
{
    public class BootstrapState : IState
    {
        private const string FirstLevelSceneName = "Level 1";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly IEnemyStaticDataService _enemyStaticDataService;

        public BootstrapState(GameStateMachine gameStateMachine, IEnemyStaticDataService enemyStaticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _enemyStaticDataService = enemyStaticDataService;
        }
        
        public void Enter()
        {
            LoadStaticDatas();
            _gameStateMachine.Enter<LoadLevelState, string>(FirstLevelSceneName);
        }

        public void Exit()
        {
        }

        private void LoadStaticDatas()
        {
            _enemyStaticDataService.Load();
        }
    }
}