using Autofac;

namespace OzerNet.WepApi.Infrastructure
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
        }
    }
}
