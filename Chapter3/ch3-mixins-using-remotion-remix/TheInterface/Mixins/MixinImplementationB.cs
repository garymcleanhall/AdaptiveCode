using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public class MixinImplementationB : IMixinInterfaceB
    {
        public void MethodB(int parameter)
        {
            Console.WriteLine("IMixinInterfaceB.MethodB({0})", parameter);
        }
    }
}
