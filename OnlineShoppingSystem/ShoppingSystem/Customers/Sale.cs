namespace ShoppingSystem.Customers
{
    public class Sale : IDiscountable
    {
        private double DiscountPercentage = 10;
        public double CalculateDiscount(double totalAmount)
        {
            return CustomerDiscount.WithPercent(totalAmount, DiscountPercentage);
        }
    }
}