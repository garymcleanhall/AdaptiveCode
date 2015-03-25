using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public class MixinImplementationC : IMixinInterfaceC
    {
        public void MethodC(string parameter)
        {
            Console.WriteLine("IMixinInterfaceC.MethodC(\"{0}\")", parameter);
        }
    }
}
