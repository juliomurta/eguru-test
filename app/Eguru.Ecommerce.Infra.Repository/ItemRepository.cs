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
    public class ItemRepository : GenericRepository<Item, int>, IItemRepository
    {
        public ItemRepository(ISession session):base(session)
        {

        }

        public override int Create(Item item)
        {
            var result = (Item) base.session.Save(item);
            return result.OrderId;//return related id order 
        }
    }
}
