using System;
using System.Linq;
using Command.Core.Models;
using Command.Core.Services.StockManager;

namespace Command.Core.Commands
{
    public class RemoveAllFromCartCommand
    {
        private readonly IStockManagerService _stockManager;
        private readonly ShoppingCart _cart;

        public RemoveAllFromCartCommand(IStockManagerService stockManager, ShoppingCart cart)
        {
            _stockManager = stockManager;
            _cart = cart;
        }

        public bool CanExecute() => _cart.Items.Any();

        public void Execute()
        {
            for (int i = 0; i < _cart.Items.Count(); i++)
            {
                var item = _cart.Items.ElementAt(i);
                _stockManager.IncreaseItemsCount(item.Name, item.Amount);
                _cart.Items.Remove(item);
            }

            Console.WriteLine($"Cart has been cleaned. Total cart price: {_cart.TotalPrice}");
        }
    }
}