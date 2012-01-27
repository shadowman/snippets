using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalizationSample.Entities
{
    public class Article
    {
        public virtual long Id { get; set; }
        public virtual String Title { get; set; }
        public virtual String Content { get; set; }
    }
}
