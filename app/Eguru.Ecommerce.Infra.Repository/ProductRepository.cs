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
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ISession session):base(session)
        {

        }
    }
}
