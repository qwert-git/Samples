using System;
using Command.Core.Models;
using Command.Core.Services.StockManager;

namespace Command.Core.Commands
{
    public class AddItemToCartCommand : ICommand
    {
        private readonly IStockManagerService _stockManager;
        private readonly ShoppingCart _cart;
        private readonly ShoppingCartItem _item;

        public AddItemToCartCommand(IStockManagerService stockManager, ShoppingCart cart, ShoppingCartItem item)
        {
            _stockManager = stockManager;
            _cart = cart;
            _item = item;
        }

        public bool CanExecute() => _stockManager.GetItemsCountLeft(_item.Name) >= _item.Amount;

        public void Execute()
        {
            _stockManager.DecreaseItemsCount(_item.Name, _item.Amount);

            _cart.Items.Add(_item);

            Console.WriteLine($"Item added. Total cart price: {_cart.TotalPrice}");
        }
    }
}