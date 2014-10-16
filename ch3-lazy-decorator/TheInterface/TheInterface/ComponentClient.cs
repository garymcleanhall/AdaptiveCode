using LazyDecoratorExample;
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

        public void Run()
        {
            component.Something();
        }

        private readonly IComponent component;
    }
}
