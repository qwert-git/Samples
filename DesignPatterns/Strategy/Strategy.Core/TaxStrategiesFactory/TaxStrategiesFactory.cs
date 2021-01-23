using Strategy.Core.TaxStrategies;

namespace Strategy.Core.TaxStrategiesFactory
{
    public class TaxStrategiesFactory
    {
        public ITaxStrategy CreateInstance(TaxStrategiesType type) =>
            type switch
            {
                TaxStrategiesType.USA => new UsaTaxStrategy(),
                TaxStrategiesType.Sweden => new SwedenTaxStrategy(),
                _ => null
            };
    }
}