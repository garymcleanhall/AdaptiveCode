using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eventing;

namespace ConsoleUIDecorators
{
    public class EntitySavedEvent<TEntity> : IEvent
    {
        public EntitySavedEvent(TEntity entity)
        {
            SavedEntity = entity;
        }

        public string Name
        {
            get { return "EntitySaved"; }
        }

        public TEntity SavedEntity
        {
            get;
            set;
        }
    }
}
