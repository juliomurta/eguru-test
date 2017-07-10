using Eguru.Ecommerce.Domain.Entities;
using Eguru.Ecommerce.Domain.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Infra.Repository
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(ISession session):base(session)
        {

        }
    }
}
