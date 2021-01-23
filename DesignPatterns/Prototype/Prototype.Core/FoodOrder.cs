using System.Text.Json;

namespace Prototype.Core
{
    public class FoodOrder : IPrototype
    {
        public string CustomerName { get; private set; }
        public bool IsDelivery { get; private set; }
        public string[] OrderContents { get; private set; }
        public OrderInfo OrderInfo { get; private set; }

        public FoodOrder(string customerName, bool isDelivery, string[] orderContents, OrderInfo orderInfo)
        {
            CustomerName = customerName;
            IsDelivery = isDelivery;
            OrderContents = orderContents;
            OrderInfo = orderInfo;
        }

        public IPrototype Clone()
        {
            var deepCopy = this.MemberwiseClone() as FoodOrder;
            deepCopy.OrderInfo = new OrderInfo(OrderInfo.Id);

            return deepCopy;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}