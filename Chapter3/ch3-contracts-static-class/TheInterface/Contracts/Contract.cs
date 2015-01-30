using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public static class Contract
    {
        public static void PreCondition(bool predicate)
        {
            if(!predicate)
            {
                throw new ArgumentException();
            }
        }
    }
}
