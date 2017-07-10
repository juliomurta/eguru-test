using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eguru.Ecommerce.Domain.Entities;
using NHibernate.Mapping;
using System.Collections.Generic;
using Eguru.Ecommerce.Application;
using NHibernate;
using StructureMap;

namespace Eguru.Ecommerce.Test.Integration
{
    [TestClass]
    public class OrderIntegrationTest
    {
        [TestMethod]
        public void Create_order_test()
        {
            var order = new Order();
            order.Items = new List<Item>();

            order.Items.Add(new Item
            {
                Product = new Product { Id = 2 },
                Quantity = 2,
                Price = 100
            });

            order.Items.Add(new Item
            {
                Product = new Product { Id = 3 },
                Quantity = 2,
                Price = 100
            });
            
            order.FormOfPayment = (int) Domain.Enums.FormOfPayment.BankSlip;

            IContainer container = new Container(new NhibernateRegistry());
            var session = container.GetInstance<ISessionFactory>();
            var orderApplication = new OrderApplication(session.OpenSession());
            orderApplication.Save(order);
        }
    }
}
