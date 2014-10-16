using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public class TargetImplementation : ITargetInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("ITargetInterface.DoSomething()");
        }
    }
}
