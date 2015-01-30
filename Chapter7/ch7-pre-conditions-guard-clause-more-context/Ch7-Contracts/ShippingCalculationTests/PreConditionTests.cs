using System;

using ShippingCalculation;

using NUnit.Framework;
using FluentAssertions;

namespace ShippingCalculationTests
{
    [TestFixture]
    public class PreConditionTests
    {
        [Test]
        public void CalculateShippingCostsRequiresPositiveWeight()
        {
            var strategy = new ShippingStrategy();

            var validSize = new Size<float> { X = 1f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(validSize, -1)).ShouldThrow<ArgumentOutOfRangeException>("Weight must be positive and non-zero").And.ParamName.Should().Equals("weightInKilograms");
        }

        [Test]
        public void CalculateShippingCostsRequiresNonZeroWeight()
        {
            var strategy = new ShippingStrategy();

            var validSize = new Size<float> { X = 1f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(validSize, 0)).ShouldThrow<ArgumentOutOfRangeException>("Weight must be positive and non-zero").And.ParamName.Should().Equals("weightInKilograms");
        }
    }
}
