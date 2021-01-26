namespace Bridge.Core.Models.Discounts
{
    public class NoDiscount : DiscountBase
    {
        public override int GetDiscount() => 0;
    }
}