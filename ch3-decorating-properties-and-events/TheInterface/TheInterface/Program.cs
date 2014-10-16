using DecoratorPattern;
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
            var client = new ComponentClient(new ComponentDecorator(new ConcreteComponent()));
            client.Process();

            Console.ReadKey();
        }
    }
}
