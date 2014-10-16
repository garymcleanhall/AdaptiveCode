using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public class MixinImplementationA : IMixinInterfaceA
    {
        public void MethodA()
        {
            Console.WriteLine("IMixinInterfaceA.MethodA()");
        }
    }
}
