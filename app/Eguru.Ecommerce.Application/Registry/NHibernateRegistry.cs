using Eguru.Ecommerce.Infra.Repository.Mapping;
using NHibernate;
using System.Configuration;
using StructureMap.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Eguru.Ecommerce.Application
{
    public class NhibernateRegistry : StructureMap.Registry
    {
        public NhibernateRegistry()
        {
            base.For<ISessionFactory>().Singleton().Use(this.ObterSessionFactory());
            base.For<ISession>().HybridHttpOrThreadLocalScoped().Use(
                x => x.GetInstance<ISession>());
        }

        private ISessionFactory ObterSessionFactory()
        {
            return Fluently.Configure()
                   .Database(
                        MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["Ecommerce"].ConnectionString)
                       .ShowSql())
                   .Mappings(c => c.FluentMappings.AddFromAssemblyOf<ProductMapping>())
                   .Mappings(c => c.FluentMappings.AddFromAssemblyOf<OrderMapping>())
                   .Mappings(c => c.FluentMappings.AddFromAssemblyOf<ItemMapping>())
                   .BuildSessionFactory();
        }
    }
}
