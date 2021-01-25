namespace Command.Core.Services.StockManager
{
    public interface IStockManagerService
    {
        int GetItemsCountLeft(string itemName);
        void IncreaseItemsCount(string itemName, int count);
        void DecreaseItemsCount(string itemName, int count);
    }
}