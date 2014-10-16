using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDecorate
{
    public class DateTester
    {
        public bool TodayIsAnEvenDayOfTheMonth
        {
            get
            {
                return DateTime.Now.Day % 2 == 0;
            }
        }
    }
}
