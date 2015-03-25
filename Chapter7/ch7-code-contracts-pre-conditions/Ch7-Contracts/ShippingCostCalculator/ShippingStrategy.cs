using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCostCalculator
{
    public class ShippingStrategy
    {
        public decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInInches, RegionInfo destination)
        {
            Contract.Requires<ArgumentOutOfRangeException>(packageWeightInKilograms > 0f, "Package weight must be positive and non-zero");
            Contract.Requires<ArgumentOutOfRangeException>(packageDimensionsInInches.X > 0f && packageDimensionsInInches.Y > 0f, "Package dimensions must be positive and non-zero");

            return decimal.MinusOne;
        }
    }
}
