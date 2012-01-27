using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalizationSample.Entities;
using FluentNHibernate.Mapping;

namespace LocalizationSample.Mappings
{
    public class ArticleMapping: ClassMap<Article>
    {
        public ArticleMapping()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Content);
        }
    }
}
