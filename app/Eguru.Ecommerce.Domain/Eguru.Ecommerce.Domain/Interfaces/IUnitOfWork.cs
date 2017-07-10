using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Domain.Interfaces
{
    public interface IUnitOfWork <TEntity, TPrimaryKey>
    {
        int Create(TEntity entity);

        void Edit(TEntity entity);

        void Delete(TPrimaryKey id);

        void BeginTransaction();

        void Commit();
    }
}
