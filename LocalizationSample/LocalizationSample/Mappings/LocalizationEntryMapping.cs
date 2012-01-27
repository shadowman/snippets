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
            Id(x => x.Id);
            Map(x => x.Translation);
            Map(x => x.Culture);
            Map(x => x.Type);
            Map(x => x.IdEntity);
            Map(x => x.Property);
        }
    }
}
