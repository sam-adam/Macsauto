using System;
using FluentNHibernate.Mapping;
using Macsauto.Domain;
using NHibernate.Engine;
using NHibernate.Id;

namespace Macsauto.Infrastructure.Persistence.Mappings
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : class
    {
        protected EntityMap()
        {
            Id(x => x.Id)
                .GeneratedBy.HiLo();
        }
    }
}