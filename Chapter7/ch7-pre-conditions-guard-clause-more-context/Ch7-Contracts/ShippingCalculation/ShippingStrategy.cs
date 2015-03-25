using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCalculation
{
    public class ShippingStrategy
    {
        public decimal CalculateShippingCost(Size<float> packageDimensionsInInches, int weightInKilograms)
        {
            if (weightInKilograms <= 0m) throw new ArgumentOutOfRangeException("weightInKilograms", "Weight must be positive and non-zero");

            return decimal.MinusOne;
        }
    }
}
