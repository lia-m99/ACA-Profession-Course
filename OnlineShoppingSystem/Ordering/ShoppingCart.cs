using Builder;
using ShoppingSystem;

namespace Ordering
{
    class ShoppingCart
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public OrderBuilder Checkout(DiscountCalculator discountCalculator)
        {
            double totalAmount = products.Sum(product => (double)product.Price);
            double discountedAmount = discountCalculator(totalAmount);

            Console.WriteLine($"Total Amount: ${totalAmount:C}");
            Console.WriteLine($"Discounted Amount: ${discountedAmount:C}");

            return new OrderBuilder().SetTotalAmount(totalAmount - discountedAmount);
        }
    }
}
