using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfilingDecorator
{
    public class ProfilingComponent : IComponent
    {
        public ProfilingComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
            stopwatch = new Stopwatch();
        }

        public void Something()
        {
            stopwatch.Start();
            decoratedComponent.Something();
            stopwatch.Stop();
            Console.WriteLine("The method took {0} seconds to complete", stopwatch.ElapsedMilliseconds / 1000);
        }

        private readonly IComponent decoratedComponent;
        private readonly Stopwatch stopwatch;
    }
}
