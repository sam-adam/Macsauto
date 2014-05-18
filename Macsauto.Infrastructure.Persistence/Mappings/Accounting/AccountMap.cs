using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class AccountMap : EntityMap<Account>
    {
        public AccountMap()
        {
            Map(x => x.Name);
            Map(x => x.Classification);
            References(x => x.Parent)
                .Not.LazyLoad();
            HasMany(x => x.Childrens)
                .Not.LazyLoad();
            HasMany(x => x.Transactions)
                .Not.LazyLoad();
        }
    }
}