using System;
using System.Linq;
using Command.Core.Models;
using Command.Core.Services.StockManager;

namespace Command.Core.Commands
{
    public class RemoveItemFromCart
    {
        private readonly IStockManagerService _stockManager;
        private readonly ShoppingCart _cart;
        private readonly ShoppingCartItem _item;

        public RemoveItemFromCart(IStockManagerService stockManager, ShoppingCart cart, ShoppingCartItem item)
        {
            _stockManager = stockManager;
            _cart = cart;
            _item = item;
        }

        public bool CanExecute() => _cart.Items.Any(i => i.Name == _item.Name);

        public void Execute()
        {
            _stockManager.IncreaseItemsCount(_item.Name, count: 1);

            var item = _cart.Items.First(i => i.Name == _item.Name);
            item.Amount -= 1;

            if (item.Amount == 0)
                _cart.Items.Remove(item);

            Console.WriteLine($"Item removed. Total cart price: {_cart.TotalPrice}");
        }
    }
}