namespace ShoppingSystem
{
    public class CustomerDiscount
    {
        public static double WithPercent(double totalAmount, double percent)
        {
            var discount_amount = (percent / 100) * totalAmount;
            return totalAmount - discount_amount;
        }
    }
}
