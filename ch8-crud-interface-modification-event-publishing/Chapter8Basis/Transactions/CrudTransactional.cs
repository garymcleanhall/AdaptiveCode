using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Crud;

namespace Transactions
{
    public class CrudTransactional<TEntity> : ICrud<TEntity>
    {
        public CrudTransactional(ICrud<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }
        public void Create(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Create(entity);

                transaction.Complete();
            }
        }

        public TEntity ReadOne(Guid identity)
        {
            TEntity entity;
            using (var transaction = new TransactionScope())
            {
                entity = decoratedCrud.ReadOne(identity);
            }
            return entity;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            IEnumerable<TEntity> allEntities;
            using (var transaction = new TransactionScope())
            {
                allEntities = decoratedCrud.ReadAll();
            }
            return allEntities;
        }

        public void Update(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Update(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Delete(entity);
            }
        }

        private readonly ICrud<TEntity> decoratedCrud;
    }
}
