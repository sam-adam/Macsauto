using Autofac;
using Macsauto.Domain;
using Macsauto.Infrastructure.Persistence.Repositories;
using NHibernate;

namespace Macsauto.Infrastructure.Persistence
{
    public class InfrastructurePersistenceModule : BaseModule
    {
        public InfrastructurePersistenceModule(string connectionString)
        {
            NHibernateSessionManager.AddSessionFactory(new NHibernateSessionFactory(connectionString));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof (Repository<>))
                .As(typeof (IRepository<>))
                .InstancePerLifetimeScope();
            builder.Register(x => NHibernateSessionManager.SessionFactory)
                .As<ISessionFactory>()
                .SingleInstance();
            builder.Register(x => NHibernateSessionManager.SessionFactory.Session)
                .As<ISession>();
        }
    }
}