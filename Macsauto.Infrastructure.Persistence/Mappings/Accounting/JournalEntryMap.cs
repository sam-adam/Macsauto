using FluentNHibernate.Mapping;
using Macsauto.Domain.Accounting.Entities;

namespace Macsauto.Infrastructure.Persistence.Mappings.Accounting
{
    public class JournalEntryMap : EntityMap<JournalEntry>
    {
        public JournalEntryMap()
        {
            References(x => x.Period);
            Map(x => x.Description);
            Map(x => x.Reference);
            Map(x => x.PostedOn)
                .Nullable();
            HasMany(x => x.JournalEntryItems)
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.All();
        }
    }
}