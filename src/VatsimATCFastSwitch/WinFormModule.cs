using Autofac;
using SimConnector;
using VatsimConnector;

namespace VatsimATCFastSwitch
{
    public class WinFormModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
            builder.RegisterModule<VatsimConnectorModule>();
            builder.RegisterModule<SimConnectorModule>();

            builder.RegisterType<MainForm>().AsSelf();
        }
    }
}
