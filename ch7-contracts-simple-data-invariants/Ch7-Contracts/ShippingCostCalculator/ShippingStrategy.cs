using System;
using System.Globalization;

namespace ShippingCostCalculator
{
    public class ShippingStrategy
    {
        public ShippingStrategy(decimal flatRate)
        {
            FlatRate = flatRate;
        }

        public decimal FlatRate
        {
            get
            {
                return flatRate;
            }
            set
            {
                if (value <= decimal.Zero)
                    throw new ArgumentOutOfRangeException("value", "Flat rate must be positive and non-zero");

                flatRate = value;
            }
        }

        public decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInInches, RegionInfo destination)
        {
            if (packageWeightInKilograms <= 0f) 
                throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Package weight must be positive and non-zero");

            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches", "Package dimensions must be positive and non-zero");

            return decimal.One;
        }

        protected decimal flatRate;
    }
}
