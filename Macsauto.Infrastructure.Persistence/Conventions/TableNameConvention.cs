using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Macsauto.Infrastructure.Extensions;

namespace Macsauto.Infrastructure.Persistence.Conventions
{
    public class TableNameConvention : IClassConvention,
        IJoinedSubclassConvention,
        IHasManyConvention
    {
        private readonly string _prefix;

        public TableNameConvention(string prefix = "")
        {
            _prefix = prefix;
        }

        public string Prefix
        {
            get { return _prefix; }
        }

        public void Apply(IClassInstance instance)
        {
            if (instance.TableName != null)
            {
                instance.Table(AlterTableName(instance.TableName, "s"));
            }
        }

        public void Apply(IJoinedSubclassInstance instance)
        {
            if (instance.TableName != null)
            {
                instance.Table(AlterTableName(instance.TableName));
            }
        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            if (instance.TableName != null)
            {
                instance.Table(AlterTableName(instance.TableName));
            }
        }

        private string AlterTableName(string tableName, string suffix = "")
        {
            return string.IsNullOrWhiteSpace(_prefix)
                ? string.Format(@"`{0}{1}`", tableName.ToCamelCase(), suffix)
                : string.Format(@"`{0}_{1}{2}`", _prefix, tableName.ToCamelCase(), suffix);
        }
    }
}