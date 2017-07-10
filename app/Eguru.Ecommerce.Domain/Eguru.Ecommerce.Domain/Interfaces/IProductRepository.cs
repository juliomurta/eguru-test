using Eguru.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product, int>, IUnitOfWork<Product, int>, IDisposable
    {

    }
}
