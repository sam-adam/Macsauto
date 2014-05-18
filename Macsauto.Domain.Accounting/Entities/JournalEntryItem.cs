using System;

namespace Macsauto.Domain.Accounting.Entities
{
    /// <summary>
    /// A single detail of JournalEntry
    /// </summary>
    public class JournalEntryItem : ValueObject<JournalEntryItem>
    {
        private readonly JournalEntry _journalEntry;
        private readonly Account _account;
        private readonly Type _type;
        private readonly Double _amount;

        public JournalEntryItem(JournalEntry journalEntry, Account account, Type type, Double amount)
        {
            _account = account;
            _journalEntry = journalEntry;
            _type = type;
            _amount = amount;
        }

        public JournalEntry JournalEntry
        {
            get { return _journalEntry; }
        }

        public Account Account
        {
            get { return _account; }
        }

        public Type Type
        {
            get { return _type; }
        }

        public bool IsDebit
        {
            get { return _type == Type.Debit; }
        }

        public bool IsCredit
        {
            get { return _type == Type.Credit; }
        }

        public Double Amount
        {
            get { return _amount; }
        }

        public void Post()
        {
            if(!_journalEntry.IsBalanced)
            {
                throw new Exception(@"Unable to post an unbalanced journal entry");
            }

            _account.AddTransaction(_journalEntry);
        }
    }

    public enum Type
    {
        Debit, Credit
    }
}