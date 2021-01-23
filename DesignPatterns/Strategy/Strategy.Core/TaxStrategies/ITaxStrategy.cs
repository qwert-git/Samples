using Strategy.Core.Models;

namespace Strategy.Core.TaxStrategies
{
    public interface ITaxStrategy
    {
        decimal GetTotalTax(Order order);
    }
}