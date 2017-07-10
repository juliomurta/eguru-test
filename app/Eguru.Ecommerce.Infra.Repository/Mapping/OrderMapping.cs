using Eguru.Ecommerce.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Infra.Repository.Mapping
{
    public class OrderMapping : ClassMap<Order>
    {
        public OrderMapping()
        {
            base.Table("[ECOMMERCE].[ORDER]");
            base.Id(x => x.Id).Column("ID");
            base.Map(x => x.Total).Column("TOTAL");
            base.Map(x => x.FormOfPayment).Column("FORMOFPAYMENT");
        }
    }
}
