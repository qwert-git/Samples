using System;

namespace Bridge.Core.Models
{
    public class LongTermMovieLicense : MovieLicense
    {
        public LongTermMovieLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime) { }

        public override DateTime? GetExpirationDate() => null;

        public override decimal GetPrice() => 8;
    }
}