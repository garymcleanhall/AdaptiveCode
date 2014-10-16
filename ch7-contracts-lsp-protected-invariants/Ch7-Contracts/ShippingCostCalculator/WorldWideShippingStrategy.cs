using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCostCalculator
{
    public class WorldWideShippingStrategy : ShippingStrategy
    {
        public WorldWideShippingStrategy(decimal flatRate)
            : base(flatRate)
        {
            
        }

        public new decimal FlatRate
        {
            get
            {
                return base.FlatRate;
            }
            set
            {
                base.FlatRate = value;
            }
        }

        public override decimal CalculateShippingCost(float packageWeightInKilograms, Size<float> packageDimensionsInInches, RegionInfo destination)
        {
            if (destination == null)
                throw new ArgumentNullException("destination", "Destination must be provided");

            if (packageWeightInKilograms <= 0f)
                throw new ArgumentOutOfRangeException("packageWeightInKilograms", "Package weight must be positive and non-zero");

            if (packageDimensionsInInches.X <= 0f || packageDimensionsInInches.Y <= 0f)
                throw new ArgumentOutOfRangeException("packageDimensionsInInches", "Package dimensions must be positive and non-zero");

            return decimal.One;
        }
    }
}
