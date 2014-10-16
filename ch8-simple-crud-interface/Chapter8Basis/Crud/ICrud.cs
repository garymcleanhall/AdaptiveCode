using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public interface ICrud<TEntity>
    {
        void Create(TEntity entity);

        TEntity ReadOne(Guid identity);

        IEnumerable<TEntity> ReadAll();

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
