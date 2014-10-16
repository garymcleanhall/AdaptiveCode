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
    public class WorldWideShippingStrategyTests
    {
        [Test]
        public void ShippingRegionMustBeProvided()
        {
            strategy.Invoking(s => s.CalculateShippingCost(1f, ValidDimensions, null))
                .ShouldThrow<ArgumentNullException>("Destination must be provided")
                .And.ParamName.Should().Be("destination");
        }

        [Test]
        public void ShippingWeightMustBePositive()
        {
            strategy.Invoking(s => s.CalculateShippingCost(-1f, ValidDimensions, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package weight must be positive and non-zero")
                .And.ParamName.Should().Be("packageWeightInKilograms");
        }

        [Test]
        public void ShippingWeightMustBeNonZero()
        {
            strategy.Invoking(s => s.CalculateShippingCost(0, ValidDimensions, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package weight must be positive and non-zero")
                .And.ParamName.Should().Be("packageWeightInKilograms");
        }

        [Test]
        public void ShippingDimensionsXMustBePositive()
        {
            var negativeSizeX = new Size<float> { X = -1f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, negativeSizeX, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsXMustBeNonZero()
        {
            var zeroSizeX = new Size<float> { X = 0f, Y = 1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, zeroSizeX, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsYMustBePositive()
        {
            var negativeSizeY = new Size<float> { X = 1f, Y = -1f };
            strategy.Invoking(s => s.CalculateShippingCost(1, negativeSizeY, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingDimensionsYMustBeNonZero()
        {
            var zeroSizeY = new Size<float> { X = 1f, Y = 0f };
            strategy.Invoking(s => s.CalculateShippingCost(1, zeroSizeY, RegionInfo.CurrentRegion))
                .ShouldThrow<ArgumentOutOfRangeException>("Package dimension must be positive and non-zero")
                .And.ParamName.Should().Be("packageDimensionsInInches");
        }

        [Test]
        public void ShippingCostMustBePositiveAndNonZero()
        {
            strategy.CalculateShippingCost(1f, ValidDimensions, RegionInfo.CurrentRegion)
                .Should().BeGreaterThan(0m);
        }

        [Test]
        public void ShippingFlatRateMustBePositive()
        {
            Action constructor = () => new ShippingStrategy(decimal.MinusOne);

            constructor.ShouldThrow<Exception>("Flat rate must be postive and non-zero");
        }

        [Test]
        public void ShippingFlatRateMustBeNonZero()
        {
            Action constructor = () => new ShippingStrategy(decimal.MinusOne);

            constructor.ShouldThrow<Exception>("Flat rate must be postive and non-zero");
        }

        [Test]
        public void ShippingFlatRateCannotBeSetToNegativeNumber()
        {
            strategy.Invoking(s => s.FlatRate = decimal.MinusOne)
                .ShouldThrow<Exception>("Flat rate must be positive and non-zero");
        }

        [SetUp]
        public void SetUp()
        {
            strategy = new WorldWideShippingStrategy(decimal.One);
        }

        private WorldWideShippingStrategy strategy;
        private readonly Size<float> ValidDimensions = new Size<float> { X = 1f, Y = 1f };
    }
}
