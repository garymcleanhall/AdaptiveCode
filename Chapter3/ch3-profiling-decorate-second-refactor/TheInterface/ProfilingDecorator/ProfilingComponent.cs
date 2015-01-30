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
        public ProfilingComponent(IComponent decoratedComponent, IStopwatch stopwatch)
        {
            this.decoratedComponent = decoratedComponent;
            this.stopwatch = stopwatch;
        }

        public void Something()
        {
            stopwatch.Start();
            decoratedComponent.Something();
            stopwatch.Stop();
        }

        private readonly IComponent decoratedComponent;
        private readonly IStopwatch stopwatch;
    }
}
