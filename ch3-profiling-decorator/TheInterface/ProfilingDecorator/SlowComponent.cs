using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfilingDecorator
{
    public class SlowComponent : IComponent
    {
        public SlowComponent()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }

        public void Something()
        {
            for(var i = 0; i<100; ++i)
            {
                Thread.Sleep(random.Next(i) * 10);
            }
        }

        private readonly Random random;
    }
}
