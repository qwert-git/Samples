namespace Bridge.Core.Models.Discounts
{
    public class SeniorDiscount : DiscountBase
    {
        public override int GetDiscount() => 20;
    }
}