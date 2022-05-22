using Autofac;

namespace SimConnector
{
    public class SimConnectorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
        }
    }
}
