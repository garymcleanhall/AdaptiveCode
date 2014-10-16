using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectsClient
{
    class LoggingUsingAspect
    {
        [Logging]
        public void FindByID(Guid id)
        {
             
        }

        [Logging]
        public void CalculatePayroll()
        {

        }
    }
}
