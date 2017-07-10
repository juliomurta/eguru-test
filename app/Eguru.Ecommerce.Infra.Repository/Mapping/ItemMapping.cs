using Eguru.Ecommerce.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Infra.Repository.Mapping
{
    public class ItemMapping : ClassMap<Item>
    {
        public ItemMapping()
        {
            base.Table("[ECOMMERCE].[ITEM]");
            base.CompositeId().KeyProperty(x => x.ProductId, "PRODUCTID").KeyProperty(x => x.OrderId, "ORDERID");
            base.Map(x => x.Quantity).Column("QUANTITY");
            base.Map(x => x.Price).Column("PRICE");
        }
    }
}
