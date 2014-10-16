using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventing
{
    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
