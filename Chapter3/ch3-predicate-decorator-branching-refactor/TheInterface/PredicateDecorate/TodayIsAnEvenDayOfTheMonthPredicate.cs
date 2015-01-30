using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDecorate
{
    public class TodayIsAnEvenDayOfTheMonthPredicate : IPredicate
    {
        public TodayIsAnEvenDayOfTheMonthPredicate(DateTester dateTester)
        {
            this.dateTester = dateTester;
        }

        public bool Test()
        {
            return dateTester.TodayIsAnEvenDayOfTheMonth;
        }

        private readonly DateTester dateTester;
    }
}
