using System;
using System.Collections.Generic;
using System.Linq;
using Macsauto.Domain;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace Macsauto.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>, IDisposable where TEntity : Entity<TEntity, TId>, IAggregateRoot
    {
        private readonly ISession _session;

        protected Repository(ISession session)
        {
            _session = session;
        }

        public ISession Session
        {
            get { return _session; }
        }

        public TEntity Find(TId id)
        {
            return _session.Get<TEntity>(id, LockMode.Read);
        }

        public long Count()
        {
            return Count(DetachedCriteria.For<TEntity>());
        }

        protected long Count(DetachedCriteria criteria)
        {
            return Convert.ToInt64(criteria.GetExecutableCriteria(_session)
                .SetProjection(Projections.RowCount())
                .UniqueResult<TEntity>());
        }

        public bool Exists(TId id)
        {
            return Count(DetachedCriteria.For<TEntity>()
                .Add(Restrictions.IdEq(id))
                ) > 0;
        }

        public IList<TEntity> GetAll()
        {
            return _session.QueryOver<TEntity>().List<TEntity>();
        }

        public long GetLastDailyIndex()
        {
            return _session.Query<TEntity>()
                .Count(entity => entity.CreatedOn.Date == DateTime.Now.Date);
        }

        public long GetLastMonthlyIndex()
        {
            return _session.Query<TEntity>()
                .Count(entity => entity.CreatedOn.Month == DateTime.Now.Month);
        }

        public void Delete(TEntity entity)
        {
            _session.Delete(entity);
        }

        protected void DeleteAll(DetachedCriteria criteria)
        {
            foreach (var entity in criteria.GetExecutableCriteria(_session).List<TEntity>())
            {
                _session.Delete(entity);
            }
        }

        public void DeleteAll()
        {
            DeleteAll(DetachedCriteria.For<TEntity>());
        }

        public TEntity Save(TEntity entity)
        {
            _session.Save(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _session.Update(entity);

            return entity;
        }

        public TEntity SaveOrUpdate(TEntity entity)
        {
            _session.SaveOrUpdate(entity);

            return entity;
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}