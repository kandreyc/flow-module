using Modules.Flow.Interactor;
using Modules.Flow.Module;
using Zenject;

namespace Modules.Flow
{
    public class FlowModuleInstaller : Installer<FlowModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IFlowModule>().To<FlowModule>().AsSingle();
            Container.Bind<FlowModel>().AsSingle().WhenInjectedInto<FlowInteractor>();
            Container.Bind<IFlowInteractor>().To<FlowInteractor>().AsSingle().WhenInjectedInto<FlowModule>();
        }
    }
}