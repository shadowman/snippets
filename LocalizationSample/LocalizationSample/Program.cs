using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;

namespace LocalizationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ISessionFactory factory = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard.InMemory()
                )
                .Mappings(x=>x.FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory();
            ISession session = factory.OpenSession();
        }
    }
}
