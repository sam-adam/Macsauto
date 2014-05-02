using FluentNHibernate.Mapping;
using Macsauto.Domain;
using NHibernate.Engine;
using NHibernate.Id;

namespace Macsauto.Infrastructure.Persistence.Mappings
{
    public abstract class EntityMap<TEntity, TId> : ClassMap<TEntity> where TEntity : Entity<TEntity, TId>
    {
        protected EntityMap()
        {
            Id(x => x.Id);
        }
    }

    public class GuidIdGenerator : IIdentifierGenerator
    {
        public object Generate(ISessionImplementor session, object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}