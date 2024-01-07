namespace ShoppingSystem.Customers
{
    public class RegularCustomer : IDiscountable
    {
        private double DiscountPercentage = 20;
        public double CalculateDiscount(double totalAmount)
        {
            return CustomerDiscount.WithPercent(totalAmount, DiscountPercentage);
        }
    }
}