namespace Bridge.Core.Models.Discounts
{
    public class MilitaryDiscount : DiscountBase
    {
        public override int GetDiscount() => 10;
    }
}