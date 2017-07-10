using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Domain.Interfaces
{
    public interface IGenericRepository<TEntity, TPrimaryKey>
    {
        TEntity Get(TPrimaryKey id);

        IEnumerable<TEntity> Search(Func<TEntity, bool> lambda = null);
    }
}
