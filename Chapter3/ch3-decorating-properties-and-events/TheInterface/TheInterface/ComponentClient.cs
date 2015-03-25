using DecoratorPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ComponentClient
    {
        public ComponentClient(IComponent component)
        {
            this.component = component;
        }

        public void Process()
        {
            component.Event += OnEvent;
            var propertyValue = component.Property;
        }

        private void OnEvent(object sender, EventArgs e)
        {
            
        }

        private readonly IComponent component;
    }
}
