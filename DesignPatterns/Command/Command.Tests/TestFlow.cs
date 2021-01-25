using System;
using Command.Core.Commands;
using Command.Core.Models;
using Command.Core.Services.StockManager;
using FluentAssertions;
using Xunit;

namespace Command.Tests
{
    public class TestFlow
    {
        [Fact]
        public void Test()
        {
            // Create commands
            string itemName = "Item1";

            var stockManager = new InMemoryStockManagerService();
            var cart = new ShoppingCart();

            var item1 = new ShoppingCartItem { Name = itemName, Amount = 1, Price = 5m };
            var item2 = new ShoppingCartItem { Name = itemName, Amount = 1, Price = 25m };

            stockManager.GetItemsCountLeft(itemName).Should().NotBe(0);

            var addCartItemCommand1 = new AddItemToCartCommand(stockManager, cart, item1);
            var addCartItemCommand2 = new AddItemToCartCommand(stockManager, cart, item1);
            var removeCartItemCommand = new RemoveItemFromCart(stockManager, cart, item1);
            var addCartItemCommand3 = new AddItemToCartCommand(stockManager, cart, item2);
            var removeAllItemsCommand = new RemoveAllFromCartCommand(stockManager, cart);

            // Execute
            if (addCartItemCommand1.CanExecute()) addCartItemCommand1.Execute();
            stockManager.GetItemsCountLeft(itemName).Should().Be(0);
            if (addCartItemCommand2.CanExecute()) addCartItemCommand2.Execute();
            if (removeCartItemCommand.CanExecute()) removeCartItemCommand.Execute();
            stockManager.GetItemsCountLeft(itemName).Should().Be(1);

            if (addCartItemCommand3.CanExecute()) addCartItemCommand3.Execute();
            stockManager.GetItemsCountLeft(itemName).Should().Be(0);

            if (removeAllItemsCommand.CanExecute()) removeAllItemsCommand.Execute();
            stockManager.GetItemsCountLeft(itemName).Should().Be(1);
        }
    }
}
