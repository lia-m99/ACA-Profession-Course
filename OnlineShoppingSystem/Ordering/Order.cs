using Builder;

namespace Ordering
{
    class Order
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public double TotalAmount { get; set; }
    }
}
