using System.Collections.Generic;
using System.Linq;

namespace Command.Core.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public IList<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice => Items.Sum(i => i.Price);
    }
}