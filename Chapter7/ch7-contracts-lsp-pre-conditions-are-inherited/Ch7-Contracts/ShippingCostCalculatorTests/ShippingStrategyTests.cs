using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShippingCostCalculator;

using NUnit.Framework;
using FluentAssertions;

namespace ShippingCostCalculatorTests
{
    public class ShippingStrategyTests : ShippingStrategyTestsBase
    {
        protected override ShippingStrategy CreateShippingStrategy()
        {
            return new ShippingStrategy(decimal.One);
        }
    }
}
