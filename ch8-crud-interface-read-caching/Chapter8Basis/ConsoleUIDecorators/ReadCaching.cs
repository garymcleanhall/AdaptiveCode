using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud;

namespace ConsoleUIDecorators
{
    public class ReadCaching<TEntity> : IRead<TEntity>
    {
        private TEntity cachedEntity;
        private IEnumerable<TEntity> allCachedEntities;

        public ReadCaching(IRead<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public TEntity ReadOne(Guid identity)
        {
            if(cachedEntity == null)
            {
                cachedEntity = decorated.ReadOne(identity);
            }
            return cachedEntity;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            }
            return allCachedEntities;
        }

        private readonly IRead<TEntity> decorated;
    }
}
