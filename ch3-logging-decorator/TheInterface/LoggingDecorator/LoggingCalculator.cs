using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingDecorator
{
    public class LoggingCalculator : ICalculator
    {
        public LoggingCalculator(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public int Add(int x, int y)
        {
            Console.WriteLine("Add(x={0}, y={1})", x, y);

            var result = calculator.Add(x, y);

            Console.WriteLine("result={0}", result);

            return result;
        }

        private readonly ICalculator calculator;
    }
}
