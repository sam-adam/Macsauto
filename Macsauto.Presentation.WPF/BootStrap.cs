using Autofac;
using Macsauto.Infrastructure.Persistence;

namespace Macsauto.Presentation.WPF
{
    public static class BootStrap
    {
        private static IContainer _container;
        private static bool _isStrapped;

        public static bool IsStrapped
        {
            get { return _isStrapped; }
        }

        public static IContainer Strap()
        {
            if (!IsStrapped)
            {
                var builder = new ContainerBuilder();

                builder.RegisterModule(new InfrastructurePersistenceModule(@"SERVER=127.0.0.1;DATABASE=macsauto;USER ID=root;PASSWORD=root"));

                _container = builder.Build();

                builder.RegisterInstance(_container).As<IContainer>();
                builder.Update(_container);

                _isStrapped = true;
            }

            return _container;
        }
    }
}