using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalizationSample.Entities
{

    public class LocalizationEntry
    {
        public virtual string IdEntity { get; set; }
        public virtual string Type { get; set; }
        public virtual string Culture { get; set; }
        public virtual string Property { get; set; }
        public virtual string Translation { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                LocalizationEntry other = obj as LocalizationEntry;
                if (other != null)
                {
                    return this.Type == other.Type &&
                            this.Property == other.Property &&
                            this.IdEntity == other.IdEntity &&
                            this.Culture == other.Culture;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
