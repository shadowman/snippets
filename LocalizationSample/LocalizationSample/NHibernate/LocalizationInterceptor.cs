using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Type;
using NHibernate.Linq;
using LocalizationSample.Entities;

namespace LocalizationSample.NHibernate
{
    public class LocalizationInterceptor : EmptyInterceptor
    {
        public LocalizationInterceptor(ISessionFactory factory, string cultureId)
        {
            Factory = factory;
            Culture = cultureId;
        }

        public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            using (ISession session = Factory.OpenSession())
            {

                var all = session.Query<LocalizationEntry>();
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    var translation = (from t in all
                                       where
                                            t.Culture == Culture &&
                                            t.IdEntity == id.ToString() &&
                                            t.Property == propertyNames[i] &&
                                            t.Type == entity.GetType().FullName
                                       select t
                    ).SingleOrDefault();
                    
                    if (translation != null)
                    {
                        state[i] = translation.Translation;
                    }
                }

                return base.OnLoad(entity, id, state, propertyNames, types);
            }
        }

        public ISessionFactory Factory { get; set; }

        public string Culture { get; set; }
    }
}
