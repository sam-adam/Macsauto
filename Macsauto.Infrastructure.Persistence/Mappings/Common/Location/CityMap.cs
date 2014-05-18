using Macsauto.Domain.Common.Entities.Location;

namespace Macsauto.Infrastructure.Persistence.Mappings.Common.Location
{
    public class CityMap : EntityMap<City>
    {
        public CityMap()
        {
            References(x => x.Province);
            Map(x => x.Name);
        }
    }
}