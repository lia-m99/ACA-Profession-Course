namespace Builder
{
    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Name} - ${Price:C}\nDescription: {Description}";
        }
    }

}
