using FluentNHibernate.Mapping;
using Macsauto.Domain;

namespace Macsauto.Infrastructure.Persistence.Mappings
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        protected EntityMap()
        {
            Not.LazyLoad();

            Id(x => x.Id)
                .GeneratedBy.GuidComb();
            Map(x => x.Code);
            Map(x => x.CreatedOn);
            Version(x => x.UpdatedOn);
        }
    }
}