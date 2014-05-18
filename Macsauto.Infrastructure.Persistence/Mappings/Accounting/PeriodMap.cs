using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class PeriodMap : EntityMap<Period>
    {
        public PeriodMap()
        {
            References(x => x.FiscalYear);
            Map(x => x.StartDate);
            Map(x => x.EndDate);
        }
    }
}