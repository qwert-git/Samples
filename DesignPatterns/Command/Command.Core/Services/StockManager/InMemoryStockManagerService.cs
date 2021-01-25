using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Command.Core.Services.StockManager
{
    public class InMemoryStockManagerService : IStockManagerService
    {
        private ConcurrentDictionary<string, int> _items = new ConcurrentDictionary<string, int>();

        public InMemoryStockManagerService()
        {
            _items.TryAdd("Item1", 1);
            _items.TryAdd("Item2", 2);
            _items.TryAdd("Item3", 3);
        }

        public void DecreaseItemsCount(string itemName, int count)
        {
            if (_items.TryGetValue(itemName, out int value))
            {
                _items.TryUpdate(itemName, value - 1, value);
            }
        }

        public int GetItemsCountLeft(string itemName)
        {
            return _items.GetValueOrDefault(itemName);
        }

        public void IncreaseItemsCount(string itemName, int count)
        {
            _items.AddOrUpdate(itemName, count, (key, exists) => exists + count);
        }
    }
}