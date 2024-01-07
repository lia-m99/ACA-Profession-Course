namespace Builder
{
    class Program
    {
        static void Main()
        {
            ProductBuilder builder = new ProductBuilder();

            Product product1 = builder.SetName("Laptop")
                                     .SetPrice(999.99m)
                                     .SetDescription("Powerful laptop with high-performance features")
                                     .Build();

            Product product2 = builder.SetName("Smartphone")
                                     .SetPrice(499.99m)
                                     .SetDescription("Latest smartphone with advanced features")
                                     .Build();

            Console.WriteLine("Product 1:\n" + product1 + "\n");
            Console.WriteLine("Product 2:\n" + product2);
        }
    }
}