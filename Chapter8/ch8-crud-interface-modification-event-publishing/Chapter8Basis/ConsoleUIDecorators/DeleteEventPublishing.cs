using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crud;
using Eventing;

namespace ConsoleUIDecorators
{
    public class ModificationEventPublishing<TEntity> : IDelete<TEntity>, ISave<TEntity>
    {
        public ModificationEventPublishing(IDelete<TEntity> decoratedDelete, ISave<TEntity> decoratedSave, IEventPublisher eventPublisher)
        {
            this.decoratedDelete = decoratedDelete;
            this.decoratedSave = decoratedSave;
            this.eventPublisher = eventPublisher;
        }

        public void Delete(TEntity entity)
        {
            decoratedDelete.Delete(entity);
            var entityDeleted = new EntityDeletedEvent<TEntity>(entity);
            eventPublisher.Publish(entityDeleted);
        }

        public void Save(TEntity entity)
        {
            decoratedSave.Save(entity);
            var entitySaved = new EntitySavedEvent<TEntity>(entity);
            eventPublisher.Publish(entitySaved);
        }

        private readonly IDelete<TEntity> decoratedDelete;
        private readonly ISave<TEntity> decoratedSave;
        private readonly IEventPublisher eventPublisher;
    }
}
