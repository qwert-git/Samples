using FluentAssertions;
using Prototype.Core;
using Xunit;

namespace Prototype.Tests
{
    public class FoodOrderTests
    {
        private FoodOrder _orderToClone;
        public FoodOrderTests()
        {
            _orderToClone = new FoodOrder("Test Customer Name", false, new[] { "Ingr1", "Ingr2" }, new OrderInfo(123));
        }

        [Theory]
        [InlineData("Test Customer Name", false, new[] { "Ingr1", "Ingr2" }, 123)]
        public void FoodOrderConstruct_Should_ReturnCorrectValues(string customerName, bool isDelivery, string[] content, int orderId)
        {
            // Arrange - Act
            var order = new FoodOrder(customerName, isDelivery, content, new OrderInfo(orderId));

            // Assert
            order.Should().Match<FoodOrder>(o =>
                o.CustomerName == customerName &&
                o.IsDelivery == isDelivery &&
                o.OrderContents == o.OrderContents &&
                o.OrderInfo.Id == orderId);
        }

        [Fact]
        public void FoodOrder_Clone_Should_BeOfFoodOrderType()
        {
            // Act
            var clonedObject = _orderToClone.Clone();

            // Assert
            clonedObject.Should().BeOfType<FoodOrder>();
        }

        [Fact]
        public void FoodOrder_Clone_Should_BeNotSameObject()
        {
            // Act
            var clonedObject = _orderToClone.Clone();

            // Assert
            clonedObject.Should().NotBeSameAs(_orderToClone);
        }
    }
}
