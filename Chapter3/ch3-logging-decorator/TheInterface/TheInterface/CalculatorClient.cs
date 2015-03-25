using LoggingDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class CalculatorClient
    {
        public CalculatorClient(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public void Run()
        {
            calculator.Add(235, 651);
        }

        private readonly ICalculator calculator;
    }
}
