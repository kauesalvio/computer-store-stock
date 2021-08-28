namespace StoreStock.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }
        public Provider Provider { get; private set; }
        public int Unity { get; private set; }

        public Product() { }

        public Product(string name, string description, decimal price, string category, Provider provider, int unity)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Provider = provider;
            Unity = unity;
        }
    }
}
