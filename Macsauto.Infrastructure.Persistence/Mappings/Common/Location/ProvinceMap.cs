using FluentNHibernate.Mapping;
using Macsauto.Domain.Common.Entities.Location;

namespace Macsauto.Infrastructure.Persistence.Mappings.Common.Location
{
    public class ProvinceMap : ClassMap<Province>
    {
        public ProvinceMap()
        {
            Map(x => x.Name);
            HasMany(x => x.Cities)
                .Cascade.SaveUpdate()
                .LazyLoad();
        }
    }
}