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
            var duck = new Duck();

            foreach (var duckling in duck)
            {
                Console.WriteLine("Quack {0}", duckling);
            }

            Console.ReadKey();
        }
    }
}
