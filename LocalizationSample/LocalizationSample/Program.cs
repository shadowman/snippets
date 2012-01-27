using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using LocalizationSample.Entities;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using System.IO;

namespace LocalizationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ISessionFactory factory = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile("sample.db")
                        .ShowSql()
                )
                .Mappings(x=>x.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(BuildDatabase)
                .BuildSessionFactory();
            
            using (ISession session = factory.OpenSession())
            {
                for (int i = 0; i < 10; i++)
                {
                    Article article = new Article();
                    article.Title = "Hello";
                    article.Content = "Something";
                    session.Save(article);
                }
            }
        }

        private static void BuildDatabase(Configuration x)
        {
            if (File.Exists("sample.db"))
            {
                File.Delete("sample.db");
            }
            new SchemaExport(x).Create(true, true);
        }
    }
}
