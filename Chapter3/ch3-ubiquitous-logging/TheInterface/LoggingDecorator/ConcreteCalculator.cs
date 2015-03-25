using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingDecorator
{
    public class ConcreteCalculator : ICalculator
    {
        public int Add(int x, int y)
        {
            Console.WriteLine("Add(x={0}, y={1})", x, y);

            var addition = x + y;

            Console.WriteLine("result={0}", addition);

            return addition;
        }
    }
}
