using FluentNHibernate;
using FluentNHibernate.Mapping;
using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class JournalEntryItemMap : ClassMap<JournalEntryItem>
    {
        public JournalEntryItemMap()
        {
            CompositeId()
                .KeyReference(x => Reveal.Member<JournalEntryItem, JournalEntry>("_journalEntry"))
                .Access.Field();
            Map(x => x.Type);
            Map(x => x.Amount);
        }
    }
}