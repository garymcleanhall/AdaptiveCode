using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShippingCostCalculator;

using NUnit.Framework;
using FluentAssertions;

namespace ShippingCostCalculatorTests
{
    [TestFixture]
    public class WorldWideShippingStrategyTests : ShippingStrategyTestsBase
    {
        [Test]
        public void ShippingRegionMustBeProvided()
        {
            strategy.Invoking(s => s.CalculateShippingCost(1f, ValidSize, null))
                .ShouldThrow<ArgumentNullException>("Destination must be provided")
                .And.ParamName.Should().Be("destination");
        }

        protected override ShippingStrategy CreateShippingStrategy()
        {
            return new WorldWideShippingStrategy(decimal.One);
        }
    }
}
