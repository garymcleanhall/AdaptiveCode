using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            stopwatch = new Stopwatch();
        }

        public void Something()
        {
            stopwatch.Start();
            for(var i = 0; i<100; ++i)
            {
                Thread.Sleep(random.Next(i) * 10);
            }
            stopwatch.Stop();
            Console.WriteLine("The method took {0} seconds to complete", stopwatch.ElapsedMilliseconds / 1000);
        }

        private readonly Random random;
        private readonly Stopwatch stopwatch;
    }
}
