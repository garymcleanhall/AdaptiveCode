using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class ComponentDecorator : IComponent
    {
        public ComponentDecorator(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public string Property
        {
            get
            {
                // We can do some mutation here, after retrieving the value
                return decoratedComponent.Property;
            }
            set
            {
                // And/or here, before we set the value
                decoratedComponent.Property = value;
            }
        }

        public event EventHandler Event
        {
            add
            {
                // We can do something here, when the event handler is registered 
                decoratedComponent.Event += value;
            }
            remove 
            {
                // And/or here, when the event handler is deregistered
                decoratedComponent.Event -= value;
            }
        }

        private readonly IComponent decoratedComponent;
    }
}
