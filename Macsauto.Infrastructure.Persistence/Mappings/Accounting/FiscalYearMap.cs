using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class FiscalYearMap : EntityMap<FiscalYear>
    {
        public FiscalYearMap()
        {
            Map(x => x.Name);
            Map(x => x.StartDate);
            Map(x => x.EndDate);
            Map(x => x.ClosedOn)
                .Nullable();
            HasMany(x => x.Periods)
                .Inverse()
                .Cascade.All();
        }
    }
}