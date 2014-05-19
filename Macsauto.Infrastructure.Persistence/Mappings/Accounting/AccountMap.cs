using FluentNHibernate.Mapping;
using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class AccountMap : EntityMap<Account>
    {
        public AccountMap()
        {
            Map(x => x.Name);
            Map(x => x.Classification);
            References(x => x.Parent);
            HasMany(x => x.Children)
                .Access.CamelCaseField(Prefix.Underscore);
            HasMany(x => x.Transactions)
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
}