using Macsauto.Domain.Common.Entities.Location;
using Macsauto.Domain.Common.Repositories;
using NHibernate;

namespace Macsauto.Infrastructure.Persistence.Repositories.Common.Location
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(ISession session) : base(session)
        {
        }
    }
}