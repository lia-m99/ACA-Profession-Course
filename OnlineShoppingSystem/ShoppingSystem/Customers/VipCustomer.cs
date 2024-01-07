namespace ShoppingSystem.Customers
{
    public class VipCustomer : IDiscountable
    {
        private double DiscountPercentage = 30;
        public double CalculateDiscount(double totalAmount)
        {
            return CustomerDiscount.WithPercent(totalAmount, DiscountPercentage);
        }
    }
}
