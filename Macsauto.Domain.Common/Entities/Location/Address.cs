namespace Macsauto.Domain.Common.Entities.Location
{
    public class Address : ValueObject<Address>
    {
        private readonly City _city;
        private readonly string _zipCode;
        private readonly string _addressLine;

        public Address(City city, string zipCode, string addressLine)
        {
            _city = city;
            _zipCode = zipCode;
            _addressLine = addressLine;
        }

        public virtual City City
        {
            get { return _city; }
        }

        public virtual string ZipCode
        {
            get { return _zipCode; }
        }

        public virtual string AddressLine
        {
            get { return _addressLine; }
        }

        public override string ToString()
        {
            if (_addressLine == null || _city == null)
            {
                return string.Empty;
            }

            return _addressLine + @", " + _city + @", " + _city.Province + @", " + _zipCode;
        }
    }
}