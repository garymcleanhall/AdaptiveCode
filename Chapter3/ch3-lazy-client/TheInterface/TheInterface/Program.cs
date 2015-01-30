using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LazyDecoratorExample;

namespace TheInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ComponentClient(new Lazy<IComponent>(() => new ConcreteComponent()));
            client.Run();
        }
    }
}
