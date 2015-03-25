using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilingDecorator
{
    public class LoggingStopwatch : IStopwatch
    {
        public LoggingStopwatch(IStopwatch decoratedStopwatch)
        {
            this.decoratedStopwatch = decoratedStopwatch;
        }

        public void Start()
        {
            decoratedStopwatch.Start();
            Console.WriteLine("Stopwatch started...");
        }

        public long Stop()
        {
            var elapsedMilliseconds = decoratedStopwatch.Stop();
            Console.WriteLine("Stopwatch stopped after {0} seconds", TimeSpan.FromMilliseconds(elapsedMilliseconds).TotalSeconds);
            return elapsedMilliseconds;
        }

        private readonly IStopwatch decoratedStopwatch;
    }
}
