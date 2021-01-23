using System.Collections.Generic;

namespace Strategy.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDelivered { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}