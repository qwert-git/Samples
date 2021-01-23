using System;
using FluentAssertions;
using Strategy.Core.TaxStrategies;
using Strategy.Core.TaxStrategiesFactory;
using Xunit;

namespace Strategy.Tests
{
    public class TaxStrategiesFactoryTests
    {
        [Theory]
        [InlineData(TaxStrategiesType.USA, typeof(UsaTaxStrategy))]
        [InlineData(TaxStrategiesType.Sweden, typeof(SwedenTaxStrategy))]
        public void CreateInstance_Should_ReturnCorrectInstance(TaxStrategiesType type, Type expectedInstanceType)
        {
            // Arrange
            var factory = new TaxStrategiesFactory();

            // Act
            var strategy = factory.CreateInstance(type);

            // Assert
            strategy.Should().BeOfType(expectedInstanceType);
        }
    }
}
