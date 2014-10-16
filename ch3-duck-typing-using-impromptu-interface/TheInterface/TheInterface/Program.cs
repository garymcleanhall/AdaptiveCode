using DuckTyping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImpromptuInterface;

namespace TheInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var swan = new Swan();

            var swanAsDuck = Impromptu.ActLike<IDuck>(swan);

            if(swanAsDuck != null)
            {
                swanAsDuck.Walk();
                swanAsDuck.Swim();
                swanAsDuck.Quack();
            }

            Console.ReadKey();
        }
    }
}
