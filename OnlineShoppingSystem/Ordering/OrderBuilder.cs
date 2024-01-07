using Builder;

namespace Ordering
{
    class OrderBuilder
    {
        private Order order = new Order();

        public OrderBuilder AddProduct(Product product)
        {
            order.Products.Add(product);
            return this;
        }

        public OrderBuilder SetTotalAmount(double totalAmount)
        {
            order.TotalAmount = totalAmount;
            return this;
        }

        public Order Build()
        {
            return order;
        }
    }

}
