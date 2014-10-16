using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eventing;

namespace ConsoleUIDecorators
{
    public class EntityDeletedEvent<TEntity> : IEvent
    {
        public EntityDeletedEvent(TEntity entity)
        {
            DeletedEntity = entity;
        }

        public string Name
        {
            get { return "EntityDeleted"; }
        }

        public TEntity DeletedEntity
        {
            get;
            set;
        }
    }
}
