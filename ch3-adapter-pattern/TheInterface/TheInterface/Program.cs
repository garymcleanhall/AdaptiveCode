using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ObjectAdapterPatternSample;

namespace TheInterface
{
    class Program
    {
        static IExpectedInterface dependency = new Adapter(new TargetClass());
        static void Main(string[] args)
        {
            dependency.MethodA();
        }
    }
}
