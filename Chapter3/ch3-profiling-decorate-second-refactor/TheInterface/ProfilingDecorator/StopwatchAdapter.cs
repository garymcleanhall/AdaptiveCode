using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilingDecorator
{
    public class StopwatchAdapter : IStopwatch
    {
        public StopwatchAdapter(Stopwatch stopwatch)
        {
            this.stopwatch = stopwatch;
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public long Stop()
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            return elapsedMilliseconds;
        }

        private readonly Stopwatch stopwatch;
    }
}
