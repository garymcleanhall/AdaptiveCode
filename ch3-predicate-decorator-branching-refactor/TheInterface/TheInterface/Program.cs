using PredicateDecorate;
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
            var example = new PredicatedDecoratorExample(new BranchedComponent(new ConcreteComponent(), new ConcreteComponent(), new TodayIsAnEvenDayOfTheMonthPredicate(new DateTester())));
            example.Run();
        }
    }
}
