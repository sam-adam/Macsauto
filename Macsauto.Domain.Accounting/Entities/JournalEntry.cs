using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Macsauto.Domain.Accounting.Entities
{
    /// <summary>
    /// A JournalEntry is a logging of transactions into accounting journal items. 
    /// The journal entry can consist of several recordings, each of which is either a debit or a credit. 
    /// The total of the debits must equal the total of the credits or the journal entry is said to be "unbalanced"
    /// </summary>
    public class JournalEntry : Entity, IAggregateRoot
    {
        private readonly Period _period;
        private readonly String _description;
        private readonly String _reference;
        private readonly IList<JournalEntryItem> _journalEntryItems;
        private DateTime? _postedOn;

        public JournalEntry(Period period, String description, String reference = "")
        {
            _period = period;
            _description = description;
            _reference = reference;
            _journalEntryItems = new List<JournalEntryItem>();
        }

        public Period Period
        {
            get { return _period; }
        }

        public String Description
        {
            get { return _description; }
        }

        public String Reference
        {
            get { return _reference; }
        }

        public IList<JournalEntryItem> Items
        {
            get { return new ReadOnlyCollection<JournalEntryItem>(_journalEntryItems); }
        }

        public DateTime? PostedOn
        {
            get { return _postedOn; }
        }

        public bool IsPosted
        {
            get { return _postedOn != null; }
        }

        public Double TotalDebit
        {
            get
            {
                return _journalEntryItems
                    .Where(x => x.Type == Type.Debit)
                    .Sum(x => x.Amount);
            }
        }

        public Double TotalCredit
        {
            get
            {
                return _journalEntryItems
                    .Where(x => x.Type == Type.Credit)
                    .Sum(x => x.Amount);
            }
        }

        public bool IsBalanced
        {
            get { return Math.Abs(TotalDebit - TotalCredit) < 1; }
        }

        public JournalEntryItem AddEntryItem(Account account, Type type, Double amount)
        {
            if(IsPosted) throw new Exception(@"Cannot add entry to posted journal");

            var entryItem = new JournalEntryItem(this, account, type, amount);

            _journalEntryItems.Add(entryItem);

            return entryItem;
        }

        public void Post()
        {
            if (!IsBalanced)
            {
                throw new Exception(@"Unable to post an unbalanced journal entry");
            }

            _postedOn = DateTime.Now;

            foreach (var journalEntryItem in _journalEntryItems)
            {
                journalEntryItem.Post();
            }
        }
    }
}