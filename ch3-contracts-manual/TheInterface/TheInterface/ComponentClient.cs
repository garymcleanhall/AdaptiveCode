using Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ComponentClient 
    {
        public void Run(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("component");
            }

            component.DoSomething();
        }
    }
}
