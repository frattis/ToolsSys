using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using NHibernate;
using RDev.ToolsSys.DataAccess.Nhibernate.Mapping;

namespace RDev.ToolsSys.DataAccess.Nhibernate
{
    public static class NhCastle
    {
        public static ISessionFactory InitSessionFactory()
        {
            FluentConfiguration cfg = Fluently.Configure()
                .Mappings
                (m => m.FluentMappings.AddFromAssemblyOf<PessoaMap>()
                          .Conventions.Setup(GetConventions()))
                .Database(MsSqlConfiguration.MsSql2008
                              .IsolationLevel("ReadCommitted")
                              .ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString"))
                /*.ShowSql()*/
                );

#if DEBUG
            cfg.Database(MsSqlConfiguration.MsSql2008.ShowSql());
#endif

            return cfg.BuildSessionFactory();
        }

        private static Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<Conventions.CascadeConvention>();
                c.Add<Conventions.EnumConvention>();
            };
        }


    }
}