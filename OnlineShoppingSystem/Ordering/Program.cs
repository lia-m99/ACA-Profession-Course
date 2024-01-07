using Builder;
using Ordering;
using ShoppingSystem;

class Program
{
    static void Main()
    {
        ShoppingCart shoppingCart = new ShoppingCart();

        Product laptop = new Product { Name = "Laptop", Price = 999.99m, Description = "Powerful laptop with high-performance features" };
        Product smartphone = new Product { Name = "Smartphone", Price = 499.99m, Description = "Latest smartphone with advanced features" };

        shoppingCart.AddProduct(laptop);
        shoppingCart.AddProduct(smartphone);

        DiscountCalculator discountCalculator = totalAmount => totalAmount * 0.1;

        Order order = shoppingCart.Checkout(discountCalculator).AddProduct(laptop).AddProduct(smartphone).Build();

        Console.WriteLine("\nFinal Order:");
        foreach (var product in order.Products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine($"Total Amount: ${order.TotalAmount:C}");
    }
}