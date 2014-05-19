using System;
using System.Linq;

namespace Macsauto.Domain.Accounting.Entities
{
    public class AccountTransaction : Entity
    {
        private readonly JournalEntry _journalEntry;
        private readonly Account _account;

        public AccountTransaction(JournalEntry journalEntry, Account account)
        {
            if(!journalEntry.IsPosted) throw new Exception(@"Cannot save unposted journal");

            _journalEntry = journalEntry;
            _account = account;
        }

        public JournalEntry JournalEntry
        {
            get { return _journalEntry; }
        }

        public Account Account
        {
            get { return _account; }
        }

        public Type TransactionType
        {
            get
            {
                return _journalEntry.JournalEntryItems
                    .First(x => x.Account == _account).Type;
            }
        }

        public DateTime? TransactionDate
        {
            get { return _journalEntry.PostedOn; }
        }

        public Double Amount
        {
            get
            {
                return _journalEntry.JournalEntryItems
                    .Where(x => x.Account == _account)
                    .Sum(x => x.Amount);
            }
        }
    }
}