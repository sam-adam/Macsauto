using Autofac;
using Autofac.Features.ResolveAnything;

namespace Macsauto.Infrastructure
{
    public abstract class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        }
    }
}