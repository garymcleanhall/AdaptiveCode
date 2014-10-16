using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ConcreteComponent : IComponent
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething was called...");
        }
    }
}
