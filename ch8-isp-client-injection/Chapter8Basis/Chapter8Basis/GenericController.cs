using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    public class GenericController<TEntity>
    {
        private readonly IRead<TEntity> reader;
        private readonly ISave<TEntity> saver;
        private readonly IDelete<TEntity> deleter;

        public GenericController(IRead<TEntity> entityReader, ISave<TEntity> entitySaver, IDelete<TEntity> entityDeleter)
        {
            reader = entityReader;
            saver = entitySaver;
            deleter = entityDeleter;
        }

        public void CreateEntity(TEntity entity)
        {
            saver.Save(entity);
        }

        public TEntity GetSingleEntity(Guid identity)
        {
            return reader.ReadOne(identity);
        }

        public void UpdateEntity(TEntity entity)
        {
            saver.Save(entity);
        }

        public void DeleteEntity(TEntity entity)
        {
            deleter.Delete(entity);
        }
    }
}
