using LoggingDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatorClient = new CalculatorClient(new LoggingCalculator(new ConcreteCalculator()));
            calculatorClient.Run();

            Console.ReadKey();
        }
    }
}
