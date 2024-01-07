namespace ShoppingSystem
{
    class Program
    {
        public static double DiscountCalculatorUser(DiscountCalculator calculator, double totalAmount)
        {
            return calculator(totalAmount);
        }

        static void Main()
        {
            TestCustomerDiscount("Regular Customer", testDiscount<Customers.RegularCustomer>);
            TestCustomerDiscount("VIP Customer", testDiscount<Customers.VipCustomer>);
            TestCustomerDiscount("Sale Customer", testDiscount<Customers.Sale>);
        }

        static void testDiscount<T>(string customerType) where T : IDiscountable, new()
        {
            var customer = new T();

            var discountedSaleAmount = DiscountCalculatorUser(customer.CalculateDiscount, 50000);

            Console.WriteLine($"{customerType} Discounted Amount: {discountedSaleAmount}");
        }

        static void TestCustomerDiscount(string customerType, Action<string> messageDelegate)
        {
            Console.WriteLine($"Testing {customerType} Customer Discount:");
            messageDelegate.Invoke(customerType);
            Console.WriteLine();
        }
    }
}