using Infrastructure.StateMachineForGame;
using Infrastructure.StateMachineForGame.States;
using Zenject;

namespace Installers
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStates();
        }

        private void BindGameStates()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<UnloadState>().AsSingle();
        }
    }
}