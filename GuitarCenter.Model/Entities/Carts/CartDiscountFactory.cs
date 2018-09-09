namespace GuitarCenter.Model.Entities.Carts
{
    public static class CartDiscountFactory
    {
        public static ICartDiscountStrategy GetDiscount(string DiscountType)
        {
            switch (DiscountType)
            {
                case "MoneyOff":
                    return new CartDiscountMoneyOff();
                default:
                    return new NoCartDiscount();
            }
        }
    }
}