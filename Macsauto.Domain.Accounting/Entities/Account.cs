using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Macsauto.Domain.Accounting.Entities
{
    /// <summary>
    /// Account or chart of accounts (COA) is a created list of 
    /// the accounts used by an organization to define each class of items for which money 
    /// or the equivalent is spent or received.
    /// </summary>
    public class Account : Entity, IAggregateRoot
    {
        private readonly IList<Account> _children;
        private readonly IList<AccountTransaction> _transactions;
        private AccountClassification _classification;
        private String _name;

        public Account(string code, String name, AccountClassification classification) : base(code)
        {
            _children = new List<Account>();
            _transactions = new List<AccountTransaction>();
            _name = name;
            _classification = classification;
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual AccountClassification Classification
        {
            get { return _classification; }
            set { _classification = value; }
        }

        public virtual Account Parent { get; set; }

        public IList<Account> Children
        {
            get { return new ReadOnlyCollection<Account>(_children); }
        } 

        public IList<AccountTransaction> Transactions
        {
            get { return new ReadOnlyCollection<AccountTransaction>(_transactions); }
        }

        public AccountTransaction AddTransaction(JournalEntry journal)
        {
            var transaction = new AccountTransaction(journal, this);
            
            _transactions.Add(transaction);

            return transaction;
        }

        public Double TotalDebits(DateTime until)
        {
            return _transactions
                .Where(x => x.TransactionDate < until && x.TransactionType == Type.Debit)
                .Sum(x => x.Amount);
        }

        public Double TotalDebits()
        {
            return TotalDebits(DateTime.Now);
        }

        public Double TotalCredits(DateTime until)
        {
            return _transactions
                .Where(x => x.TransactionDate < until && x.TransactionType == Type.Credit)
                .Sum(x => x.Amount);
        }

        public Double TotalCredits()
        {
            return TotalCredits(DateTime.Now);
        }

        public Double Balance(DateTime asOf)
        {
            return TotalDebits(asOf) - TotalCredits(asOf);
        }

        public Double Balance()
        {
            return Balance(DateTime.Now);
        }

        public void AddChild(Account account)
        {
            _children.Add(account);

            account.Parent = this;
        }
    }
}