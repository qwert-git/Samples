using System;
using Bridge.Core.Models.Discounts;

namespace Bridge.Core.Models
{
    public class TwoDaysMovieLicense : MovieLicenseBase
    {
        public TwoDaysMovieLicense(string movie, DateTime purchaseTime, DiscountBase discount) : base(movie, purchaseTime, discount)
        {
        }

        public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);

        protected override decimal GetPriceCore() => 4;
    }
}