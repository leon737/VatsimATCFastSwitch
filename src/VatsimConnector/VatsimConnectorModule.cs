using Autofac;

namespace VatsimConnector
{
    public class VatsimConnectorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
        }
    }
}
