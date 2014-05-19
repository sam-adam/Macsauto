using FluentNHibernate;
using FluentNHibernate.Mapping;
using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class JournalEntryItemMap : ClassMap<JournalEntryItem>
    {
        public JournalEntryItemMap()
        {
            Not.LazyLoad();

            CompositeId()
                .KeyReference(x => x.JournalEntry, map => map.Access.CamelCaseField(Prefix.Underscore));
            Map(x => x.Type);
            Map(x => x.Amount);
        }
    }
}