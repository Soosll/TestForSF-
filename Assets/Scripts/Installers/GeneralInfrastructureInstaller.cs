using Infrastructure.AssetManagement;
using Infrastructure.General;
using Infrastructure.Handlers.CoroutineHandler;
using Infrastructure.Handlers.HeroHandler;
using Zenject;

namespace Installers
{
    public class GeneralInfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGame>().To<Game>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunnerHandler>().To<CoroutineRunnerHandler>().AsSingle();
            Container.Bind<IHeroHandler>().To<HeroHandler>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
    }
}