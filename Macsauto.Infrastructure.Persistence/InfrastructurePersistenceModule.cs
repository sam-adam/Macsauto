using Autofac;
using Macsauto.Domain;
using Macsauto.Infrastructure.Persistence.Repositories;
using NHibernate;

namespace Macsauto.Infrastructure.Persistence
{
    public class InfrastructurePersistenceModule : BaseModule
    {
        private readonly NHibernateSessionFactory _sessionFactory;

        public InfrastructurePersistenceModule(string connectionString)
        {
            _sessionFactory = new NHibernateSessionFactory(connectionString);

            _sessionFactory.Initialize();
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof (Repository<>))
                .As(typeof (IRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterInstance(_sessionFactory)
                .As<ISessionFactory>()
                .SingleInstance();
            builder.Register(x => _sessionFactory.Session)
                .As<ISession>();
        }
    }
}