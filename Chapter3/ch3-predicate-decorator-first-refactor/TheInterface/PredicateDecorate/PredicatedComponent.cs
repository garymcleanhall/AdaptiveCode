using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDecorate
{
    public class PredicatedComponent : IComponent
    {
        public PredicatedComponent(IComponent decoratedComponent, DateTester dateTester)
        {
            this.decoratedComponent = decoratedComponent;
            this.dateTester = dateTester;
        }
        
        public void Something()
        {
            if(dateTester.TodayIsAnEvenDayOfTheMonth)
            {
                decoratedComponent.Something();
            }
        }

        private readonly IComponent decoratedComponent;
        private readonly DateTester dateTester;
    }
}
