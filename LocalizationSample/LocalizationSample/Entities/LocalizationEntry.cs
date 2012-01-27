using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalizationSample.Entities
{
    public class LocalizationEntry
    {
        public virtual long Id { get; set; }
        public virtual string IdEntity { get; set; }
        public virtual string Type { get; set; }
        public virtual string Culture { get; set; }
        public virtual string Translation { get; set; }
        public virtual string Property { get; set; }
    }
}
