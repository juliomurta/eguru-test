using Eguru.Ecommerce.Domain.Entities;
using Eguru.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Eguru.Ecommerce.Infra.Repository;

namespace Eguru.Ecommerce.Application
{
    public class ProductApplication
    {
        protected IProductRepository productRepository = null;

        public ProductApplication(ISession session)
        {
            this.productRepository = new ProductRepository(session);
        }

        public IEnumerable<Product> Search(Func<Product, bool> lambda = null)
        {
            return this.productRepository.Search(lambda);
        }

        public Product Get(int id)
        {
            return this.productRepository.Get(id);
        }
    }
}
