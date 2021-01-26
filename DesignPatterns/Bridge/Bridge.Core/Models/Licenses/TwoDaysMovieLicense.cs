using System;

namespace Bridge.Core.Models
{
    public class TwoDaysMovieLicense : MovieLicense
    {
        public TwoDaysMovieLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime) { }

        public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);

        public override decimal GetPrice() => 4;
    }
}