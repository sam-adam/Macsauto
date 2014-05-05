using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Macsauto.Domain.Common.Entities.Location
{
    public class Province : Entity, IAggregateRoot
    {
        private readonly IList<City> _cities;
        private string _name;

        public Province(string name)
        {
            _cities = new List<City>();
            _name = name;
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual ReadOnlyCollection<City> Cities
        {
            get { return new ReadOnlyCollection<City>(_cities); }
        }

        public void AddCity(City city)
        {
            if(_cities.Contains(city))
                throw new ArgumentException(@"City already registered");

            _cities.Add(city);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
