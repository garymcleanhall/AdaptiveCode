using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCostCalculator
{
    public class WorldWideShippingStrategy
    {
        public WorldWideShippingStrategy(decimal flatRate)
        {
            if (flatRate <= decimal.Zero)
                throw new ArgumentOutOfRangeException("flatRate", "Flat rate must be positive and non-zero");

            this.flatRate = flatRate;
        }

        public decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInInches, RegionInfo destination)
        {
            if (destination == null)
                throw new ArgumentNullException("destination", "Destination must be provided");

            if (packageWeightInKilograms <= 0f)
                throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Package weight must be positive and non-zero");

            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches", "Package dimensions must be positive and non-zero");

            return decimal.One;
        }

        private decimal flatRate;
    }
}
