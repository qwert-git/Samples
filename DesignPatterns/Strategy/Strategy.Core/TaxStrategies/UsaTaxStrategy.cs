using System.Linq;
using Strategy.Core.Models;

namespace Strategy.Core.TaxStrategies
{
    public class UsaTaxStrategy : ITaxStrategy
    {
        public decimal GetTotalTax(Order order)
        {
            decimal total = order.Items.Sum(i => i.Price);
            return total * 0.25m;
        }
    }
}