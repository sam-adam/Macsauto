using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Macsauto.Infrastructure.Extensions;

namespace Macsauto.Infrastructure.Persistence.Conventions
{
    public class ColumnNameConvention : ForeignKeyConvention,
        IIdConvention,
        IPropertyConvention,
        IVersionConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            return property == null
                ? type.Name.ToCamelCase()
                : property.Name.ToCamelCase();
        }

        public void Apply(IIdentityInstance instance)
        {
            instance.Column(@"id");
        }

        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property != null)
            {
                instance.Property.Name.ToCamelCase();
            }
        }

        public void Apply(IVersionInstance instance)
        {
            instance.Column(instance.Name.ToCamelCase());
        }
    }
}