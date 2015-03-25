using Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ComponentClient 
    {
        public ComponentClient(IComponent component)
        {
            Contract.Requires<ArgumentNullException>(component != null);

            this.component = component;
        }

        public void Run()
        {
            component.DoSomething();
        }

        private readonly IComponent component;
    }
}
