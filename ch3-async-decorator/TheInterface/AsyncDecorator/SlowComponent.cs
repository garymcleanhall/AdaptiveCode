using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDecorator
{
    public class SlowComponent : IComponent
    {
        public void Process()
        {
            Thread.Sleep(6000);
        }
    }
}
