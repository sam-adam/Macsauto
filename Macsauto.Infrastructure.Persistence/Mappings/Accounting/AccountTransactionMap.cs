using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class AccountTransactionMap : EntityMap<AccountTransaction>
    {
        public AccountTransactionMap()
        {
            References(x => x.JournalEntry);
            References(x => x.Account);
        }
    }
}