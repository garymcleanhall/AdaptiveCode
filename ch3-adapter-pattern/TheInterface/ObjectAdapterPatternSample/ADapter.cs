using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAdapterPatternSample
{
    public class Adapter : IExpectedInterface
    {
        public Adapter(TargetClass target)
        {
            this.target = target;
        }

        public void MethodA()
        {
            target.MethodB();
        }

        private TargetClass target;
    }
}
