using System;
using Bridge.Core.Models.Discounts;

namespace Bridge.Core.Models
{
    public class LongTermMovieLicense : MovieLicenseBase
    {
        public LongTermMovieLicense(string movie, DateTime purchaseTime, DiscountBase discount) : base(movie, purchaseTime, discount)
        {
        }

        public override DateTime? GetExpirationDate() => null;

        protected override decimal GetPriceCore() => 8;
    }
}