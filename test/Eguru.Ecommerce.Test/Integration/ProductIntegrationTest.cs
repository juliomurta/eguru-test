using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eguru.Ecommerce.Application;
using System.Collections.Generic;
using System.Linq;
using StructureMap;
using NHibernate;

namespace Eguru.Ecommerce.Test.Integration
{
    [TestClass]
    public class ProductIntegrationTest
    {
        [TestMethod]
        public void Listing_products_in_the_database()
        {
            IContainer container = new Container(new NhibernateRegistry());
            var session = container.GetInstance<ISessionFactory>();
            var producApplication = new ProductApplication(session.OpenSession());
            var products = producApplication.Search(null).ToList();
            Assert.AreNotEqual(0, products.Count);
        }
    }
}
