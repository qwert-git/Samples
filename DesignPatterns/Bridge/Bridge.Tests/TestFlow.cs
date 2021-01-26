using System;
using Bridge.Core.Models;
using Bridge.Core.Models.Discounts;
using FluentAssertions;
using Xunit;

namespace Bridge.Tests
{
    public class TestFlow
    {
        [Fact]
        public void NoDiscount_Should_ReturnStandartPrice()
        {
            // Arrange
            var noDiscount = new NoDiscount();

            var license1 = new TwoDaysMovieLicense("Movie Name 1", DateTime.UtcNow, noDiscount);
            var license2 = new LongTermMovieLicense("Movie Name 2", DateTime.UtcNow, noDiscount);

            // Act - Assert
            license1.GetPrice().Should().Be(4);
            license2.GetPrice().Should().Be(8);
        }

        [Fact]
        public void MilitaryDiscount_Should_ReturnPriceWithDiscount()
        {
            // Arrange
            var militaryDiscount = new MilitaryDiscount();

            var twoDaysLicense = new TwoDaysMovieLicense("Movie Name 1", DateTime.UtcNow, militaryDiscount);
            var longTernLicense = new LongTermMovieLicense("Movie Name 2", DateTime.UtcNow, militaryDiscount);

            // Act - Assert
            twoDaysLicense.GetPrice().Should().Be(4 * 0.9m);
            longTernLicense.GetPrice().Should().Be(8 * 0.9m);
        }

        [Fact]
        public void SeniorDiscount_Should_ReturnPriceWithDiscount()
        {
            // Arrange
            var seniorDiscount = new SeniorDiscount();

            var twoDaysLicense = new TwoDaysMovieLicense("Movie Name 1", DateTime.UtcNow, seniorDiscount);
            var longTernLicense = new LongTermMovieLicense("Movie Name 2", DateTime.UtcNow, seniorDiscount);

            // Act - Assert
            twoDaysLicense.GetPrice().Should().Be(4 * 0.8m);
            longTernLicense.GetPrice().Should().Be(8 * 0.8m);
        }
    }
}
