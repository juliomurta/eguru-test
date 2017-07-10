using Eguru.Ecommerce.Application;
using NHibernate;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eguru.Ecommerce.Web.Singleton
{
    public static class SessionManager
    {
        public static ISession GetInstance()
        {
            IContainer container = new Container(new NhibernateRegistry());
            var session = container.GetInstance<ISessionFactory>();
            return session.OpenSession();
        }
    }
}