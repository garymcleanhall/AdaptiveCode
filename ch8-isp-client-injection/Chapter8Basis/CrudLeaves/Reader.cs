using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudImplementations
{
    public class Reader<TEntity> : IRead<TEntity>
    {
        public TEntity ReadOne(Guid identity)
        {
            return default(TEntity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return new List<TEntity>();
        }
    }
}
