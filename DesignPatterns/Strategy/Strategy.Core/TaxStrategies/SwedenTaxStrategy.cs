using Strategy.Core.Models;

namespace Strategy.Core.TaxStrategies
{
    public class SwedenTaxStrategy : ITaxStrategy
    {
        public decimal GetTotalTax(Order order)
        {
            decimal totalTax = 0;
            foreach (var item in order.Items)
            {
                if (item.ProductType == "Service")
                {
                    totalTax += item.Price * 0.2m;
                }
                if (item.ProductType == "Grocery")
                {
                    totalTax += item.Price * 0.25m;
                }
            }

            return totalTax;
        }
    }
}