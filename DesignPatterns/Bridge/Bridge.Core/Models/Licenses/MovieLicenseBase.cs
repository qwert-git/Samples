using System;
using Bridge.Core.Models.Discounts;

namespace Bridge.Core.Models
{
    public abstract class MovieLicenseBase
    {
        private readonly DiscountBase _discount;
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        protected MovieLicenseBase(string movie, DateTime purchaseTime, DiscountBase discount)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
        }

        public decimal GetPrice()
        {
            int discount = _discount.GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return GetPriceCore() * multiplier;
        }

        protected abstract decimal GetPriceCore();

        public abstract DateTime? GetExpirationDate();
    }
}