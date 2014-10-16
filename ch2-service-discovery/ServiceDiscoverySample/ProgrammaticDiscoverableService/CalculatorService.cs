using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammaticDiscoverableService
{
    public class CalculatorService : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
