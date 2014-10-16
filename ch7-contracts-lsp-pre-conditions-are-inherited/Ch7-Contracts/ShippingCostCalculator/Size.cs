using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCostCalculator
{
    public struct Size<TIntegral>
        where TIntegral : struct
    {
        public TIntegral X;
        public TIntegral Y;
    }
}
