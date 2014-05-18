using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Macsauto.Infrastructure.Persistence.Conventions;
using Macsauto.Infrastructure.Persistence.Mappings.Common.Location;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace Macsauto.Infrastructure.Persistence
{
    /// <summary>
    /// NHibernate's SessionFactory wrapper
    /// </summary>
    public class NHibernateSessionFactory
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;
        private bool _isInitialized;

        public NHibernateSessionFactory(string connectionString)
        {
            _connectionString = connectionString;
            _isInitialized = false;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        /// Get SessionFactory's current session if available,
        /// otherwise open another one
        /// </summary>
        public ISession Session
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exception(@"SessionFactory is not initialized");
                }

                return _sessionFactory.GetCurrentSession() ?? _sessionFactory.OpenSession();
            }
        }

        /// <summary>
        /// Get SessionFactory's current stateless session if available,
        /// otherwise open another one
        /// </summary>
        public IStatelessSession StatelessSession
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exception(@"SessionFactory is not initialized");
                }

                return _sessionFactory.OpenStatelessSession();
            }
        }

        /// <summary>
        /// True if the Initiliaze() method has been called, otherwise false
        /// </summary>
        public bool IsInitialized
        {
            get { return _isInitialized; }
        }

        /// <summary>
        /// Initialize the SessionFactory
        /// </summary>
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
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            _isInitialized = true;
        }

        private void BuildSchema(Configuration conf)
        {
            new SchemaUpdate(conf).Execute(false, true);
        }
    }
}