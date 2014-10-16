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
    [TestFixture]
    public class ShippingStrategyTests
    {
        [Test]
        public void ShippingWeightMustBePositive()
        {
            strategy.Invoking(s => s.CalculateShippingCost(-1f, ValidSize, null))
                .ShouldThrow<ArgumentOutOfRangeException>("Package weight must be positive and non-zero")
                .And.ParamName.Should().Be("packageWeightInKilograms");
        }

        [Test]
        public void ShippingWeightMustBeNonZero()
        {
            strategy.Invoking(s => s.CalculateShippingCost(0, ValidSize, null))
                .ShouldThrow<ArgumentOutOfRangeException>("Package weight must be positive and non-zero")
                .And.ParamName.Should().Be("packageWeightInKilograms");
        }

        [Test]
        public void ShippingDimensionsXMustBePositive()
        {
            var negativeSizeX = new Size<float> { X = -1f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, negativeSizeX, null))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsXMustBeNonZero()
        {
            var zeroSizeX = new Size<float> { X = 0f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, zeroSizeX, null))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsYMustBePositive()
        {
            var negativeSizeY = new Size<float> { X = 1f, Y = -1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, negativeSizeY, null))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsYMustBeNonZero()
        {
            var zeroSizeY = new Size<float> { X = 1f, Y = 0f };
            strategy.Invoking(s => s.CalculateShippingCost(1, zeroSizeY, null))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }


        [SetUp]
        public void SetUp()
        {
            strategy = new ShippingStrategy();
        }

        private ShippingStrategy strategy;
        private readonly Size<float> ValidSize = new Size<float> { X = 1f, Y = 1f };
    }
}
