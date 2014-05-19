using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;

namespace Macsauto.Infrastructure.Persistence.Conventions
{
    public class ReferenceConvention : IReferenceConvention, IHasManyConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.LazyLoad(Laziness.NoProxy);
        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Not.LazyLoad();
        }
    }
}
