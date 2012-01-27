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
using System.Threading;
using LocalizationSample.NHibernate;

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
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(BuildDatabase)
                .BuildSessionFactory();

            Article article = null;
            String cultureId = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;

            using (ISession session = factory.OpenSession())
            {

                article = new Article()
                {
                    Title = "English Title",
                    Content = "English Content"
                };

                session.Save(article);
                
                session.Save(new LocalizationEntry
                {
                    Culture = cultureId,
                    IdEntity = article.Id.ToString(),
                    Translation = "Spanish Title",
                    Type = typeof(Article).FullName,
                    Property = "Title"
                });
                session.Save(new LocalizationEntry
                {
                    Culture = cultureId,
                    IdEntity = article.Id.ToString(),
                    Translation = "Spanish Content",
                    Type = typeof(Article).FullName,
                    Property = "Title"
                });
            }

            using (ISession session = factory.OpenSession())
            {
                article = session.Load<Article>(article.Id);

                Console.WriteLine("Title: " + article.Title);
            }

            using (ISession session = factory.OpenSession(new LocalizationInterceptor(factory, cultureId)))
            {
                article = session.Load<Article>(article.Id);

                Console.WriteLine("Title: " + article.Title);
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
