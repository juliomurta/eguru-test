using Eguru.Ecommerce.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Infra.Repository.Mapping
{
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            base.Table("[ECOMMERCE].[PRODUCT]");
            base.Id(x => x.Id).Column("ID");
            base.Map(x => x.Name).Column("NAME");
            base.Map(x => x.Description).Column("DESCRIPTION");
            base.Map(x => x.Quantity).Column("QUANTITY");
            base.Map(x => x.Price).Column("PRICE");
            base.Map(x => x.ImagePath).Column("IMAGEPATH");            
        }
    }
}
