namespace Macsauto.Domain.Inventory.Entities
{
    /// <summary>
    /// Inventory refers to the goods and materials that is kept
    /// for sales or other usage
    /// </summary>
    public class Inventory : Entity, IAggregateRoot
    {
        private UnitOfMeasurement _uoM;
        private string _name;
        private string _description;
        private long _buyPrice;

        public Inventory(string code, string name, string description, long buyPrice, UnitOfMeasurement uoM) : base(code)
        {
            _name = name;
            _buyPrice = buyPrice;
            _description = description;
            _uoM = uoM;
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual UnitOfMeasurement UoM
        {
            get { return _uoM; }
            set { _uoM = value; }
        }

        public virtual long BuyPrice
        {
            get { return _buyPrice; }
            set { _buyPrice = value; }
        }
    }
}