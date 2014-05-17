namespace Macsauto.Domain.Inventory.Entities
{
    /// <summary>
    /// Represents an unit of measurement (UOM) used across the system.
    /// Examples : Cm, M, Kg, Pcs
    /// </summary>
    public class UnitOfMeasurement : ValueObject<UnitOfMeasurement>
    {
        private readonly string _name;
        private readonly string _description;

        public UnitOfMeasurement(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}