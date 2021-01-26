using System;

namespace Bridge.Core.Models
{
    public abstract class MovieLicenseBase
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        protected MovieLicenseBase(string movie, DateTime purchaseTime)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
        }

        public abstract decimal GetPrice();
        public abstract DateTime? GetExpirationDate();
    }
}