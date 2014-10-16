using System;
using System.Globalization;

namespace ShippingCostCalculator
{
    public class ShippingStrategy
    {
        public ShippingStrategy(decimal flatRate)
        {
            if (flatRate <= decimal.Zero)
                throw new ArgumentOutOfRangeException("flatRate", "Flat rate must be positive and non-zero");

            this.flatRate = flatRate;
        }

        public virtual decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInInches, RegionInfo destination)
        {
            if (packageWeightInKilograms <= 0f) 
                throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Package weight must be positive and non-zero");

            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches", "Package dimensions must be positive and non-zero");


            var shippingCost = decimal.One;

            if(shippingCost <= decimal.Zero)
                throw new ArgumentOutOfRangeException("return", "The return value is out of range");
            
            return shippingCost;
        }

        protected decimal flatRate;
    }
}
