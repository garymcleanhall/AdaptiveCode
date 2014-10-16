using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudImplementations
{
    public class Crud<TEntity> : IRead<TEntity>, ISave<TEntity>, IDelete<TEntity>
    {
        public TEntity ReadOne(Guid identity)
        {
            return default(TEntity);   
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return new List<TEntity>();
        }

        public void Save(TEntity entity)
        {
            
        }

        public void Delete(TEntity entity)
        {
            
        }
    }
}
