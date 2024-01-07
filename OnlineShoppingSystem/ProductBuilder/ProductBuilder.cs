namespace Builder
{
    internal class ProductBuilder
    {
        private Product product;

        public ProductBuilder()
        {
            product = new Product();
        }

        public ProductBuilder SetName(string name)
        {
            product.Name = name;
            return this;
        }

        public ProductBuilder SetPrice(decimal price)
        {
            product.Price = price;
            return this;
        }

        public ProductBuilder SetDescription(string description)
        {
            product.Description = description;
            return this;
        }

        public Product Build()
        {
            return product;
        }
    }
}
