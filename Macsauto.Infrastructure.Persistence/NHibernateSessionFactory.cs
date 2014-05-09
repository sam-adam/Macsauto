using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Macsauto.Infrastructure.Persistence.Conventions;
using Macsauto.Infrastructure.Persistence.Mappings.Common.Location;
using NHibernate;
using NHibernate.Context;

namespace Macsauto.Infrastructure.Persistence
{
    public class NHibernateSessionFactory
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public NHibernateSessionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public ISession Session
        {
            get { return _sessionFactory.GetCurrentSession() ?? _sessionFactory.OpenSession(); }
        }

        public IStatelessSession StatelessSession
        {
            get { return _sessionFactory.OpenStatelessSession(); }
        }

        public void Initialize()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
                .CurrentSessionContext<ThreadLocalSessionContext>()
                .Mappings(map =>
                {
                    map.FluentMappings.Conventions.AddFromAssemblyOf<ColumnNameConvention>();
                    map.FluentMappings.AddFromAssemblyOf<ProvinceMap>();
                })
                .BuildSessionFactory();
        }
    }
}