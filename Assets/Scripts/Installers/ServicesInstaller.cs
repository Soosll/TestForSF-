using Services.ForDispose;
using Services.ForInput;
using Services.ForStaticData.ForEnemy;
using Zenject;

namespace Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.Bind<IEnemyStaticDataService>().To<EnemyStaticDataService>().AsSingle();
            Container.Bind<IDisposeService>().To<DisposeService>().AsSingle();
        }
    }
}