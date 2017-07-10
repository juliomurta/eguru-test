using Eguru.Ecommerce.Domain.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Eguru.Ecommerce.Infra.Repository
{
    public abstract class GenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey>, IUnitOfWork<TEntity, TPrimaryKey>, IDisposable where TEntity : class
    {
        protected ISession session = null;
        protected ITransaction transaction = null;

        public GenericRepository(ISession session)
        {
            this.session = session;
        }

        public virtual void BeginTransaction()
        {
            this.transaction = session.BeginTransaction();
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            return this.session.Get<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> Search(Func<TEntity, bool> lambda = null)
        {
            if (lambda == null)
            {
                return this.session.CreateCriteria<TEntity>().List<TEntity>();
            }
            else
            {
                return this.session.CreateCriteria<TEntity>()
                                    .List<TEntity>()
                                    .Where(lambda)
                                    .AsEnumerable();
            }
        }

        public virtual int Create(TEntity entity)
        {
            return (int)this.session.Save(entity);
        }

        public virtual void Delete(TPrimaryKey id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.session.Delete(entity);
            }
        }

        public virtual void Edit(TEntity entity)
        {
            this.session.Update(entity);
        }

        public virtual void Commit()
        {
            this.transaction.Commit();
        }

        public virtual void Dispose()
        {
            if (this.session != null)
            {
                this.session.Dispose();
            }

            if (this.transaction != null)
            {
                this.transaction.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
