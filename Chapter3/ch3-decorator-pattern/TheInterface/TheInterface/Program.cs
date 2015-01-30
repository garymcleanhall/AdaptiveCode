using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DecoratorPattern;

namespace TheInterface
{
    class Program
    {
        static IComponent component;

        static void Main(string[] args)
        {
            component = new DecoratorComponent(new ConcreteComponent());
            component.Something();
        }
    }
}
