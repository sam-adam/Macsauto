using System;
using NHibernate;

namespace Macsauto.Infrastructure.Persistence
{
    /// <summary>
    /// Static provider / factory for NHibernateSessionFactory and
    /// utility functions and extensions
    /// </summary>
    public static class NHibernateSessionManager
    {
        private static NHibernateSessionFactory _sessionFactory;

        /// <summary>
        /// Register NHibernateSessionFactory to handle
        /// </summary>
        /// <param name="sessionFactory"></param>
        public static void AddSessionFactory(NHibernateSessionFactory sessionFactory)
        {
            if (!sessionFactory.IsInitialized)
            {
                sessionFactory.Initialize();
            }

            _sessionFactory = sessionFactory;
        }

        public static NHibernateSessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        /// <summary>
        /// Utility extension to provide transactional capability without AOP
        /// </summary>
        /// <param name="session">The session being used</param>
        /// <param name="action">Action inside transactional scope</param>
        public static void DoTransaction(this ISession session, Action<ISession> action)
        {
            using (var transaction = session.BeginTransaction())
            {
                action(session);

                try
                {
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    
                    throw;
                }
            }
        }
    }
}