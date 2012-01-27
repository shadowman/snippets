using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalizationSample.Entities;
using FluentNHibernate.Mapping;

namespace LocalizationSample.Mappings
{
    public class LocalizationEntryMapping: ClassMap<LocalizationEntry>
    {
        public LocalizationEntryMapping()
        {
            CompositeId()
                .KeyProperty(x => x.Culture)
                .KeyProperty(x => x.IdEntity)
                .KeyProperty(x => x.Property)
                .KeyProperty(x => x.Type);
            Map(x => x.Translation);
        }
    }
}
