namespace Macsauto.Domain.Accounting.Entities
{
    public class Account : Entity, IAggregateRoot
    {
        private string _name;
        private AccountClassification _classification;
        private double _debit;
        private double _credit;

        public Account(string code, string name, AccountClassification classification) : base(code)
        {
            _name = name;
            _classification = classification;
            _debit = 0;
            _credit = 0;
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

        public virtual double Debit
        {
            get { return _debit; }
            set { _debit = value; }
        }

        public virtual double Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }
    }
}