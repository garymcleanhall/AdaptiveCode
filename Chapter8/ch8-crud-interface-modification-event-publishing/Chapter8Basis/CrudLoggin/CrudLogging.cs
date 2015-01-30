using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Crud;

namespace CrudLogging
{
    public class CrudLogging<TEntity> : ICrud<TEntity>
    {
        public CrudLogging(ICrud<TEntity> decoratedCrud, ILog log)
        {
            this.decoratedCrud = decoratedCrud;
            this.log = log;
        }

        public void Create(TEntity entity)
        {
            log.InfoFormat("Creating entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Create(entity);
        }

        public TEntity ReadOne(Guid identity)
        {
            log.InfoFormat("Reading entity of type {0} with identity {1}", typeof(TEntity).Name, identity);
            return decoratedCrud.ReadOne(identity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            log.InfoFormat("Reading all entities of type {0}", typeof(TEntity).Name);
            return decoratedCrud.ReadAll();
        }

        public void Update(TEntity entity)
        {
            log.InfoFormat("Updating entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            log.InfoFormat("Deleting entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Delete(entity);
        }

        private readonly ICrud<TEntity> decoratedCrud;
        private readonly ILog log;
    }
}