using DuckTyping;
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
            var swan = new Swan();

            var swanAsDuck = swan as IDuck;

            if(swan is IDuck || swanAsDuck != null)
            {
                swanAsDuck.Walk();
                swanAsDuck.Swim();
                swanAsDuck.Quack();
            }
        }
    }
}
