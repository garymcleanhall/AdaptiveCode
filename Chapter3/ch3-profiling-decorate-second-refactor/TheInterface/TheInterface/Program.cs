using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProfilingDecorator;
using System.Diagnostics;

namespace TheInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ComponentClient(new ProfilingComponent(new SlowComponent(), new LoggingStopwatch(new StopwatchAdapter(new Stopwatch()))));
            client.Run();

            Console.ReadKey();
        }
    }
}
