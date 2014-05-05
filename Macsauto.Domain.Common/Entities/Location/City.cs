namespace Macsauto.Domain.Common.Entities.Location
{
    public class City : Entity
    {
        private readonly Province _province;
        private string _name;

        public City(Province province, string name)
        {
            _province = province;
            _name = name;

            _province.AddCity(this);
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual Province Province
        {
            get { return _province; }
        }
    }
}