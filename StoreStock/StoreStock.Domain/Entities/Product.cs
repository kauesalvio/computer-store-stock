namespace StoreStock.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public long Price { get; private set; }
        public string Category { get; private set; }
        public string Provider { get; private set; }
        public int Unity { get; private set; }

        public Product() { }

        public Product(string name, string description, long price, string category, string provider, int unity)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Provider = provider;
            Unity = unity;
        }

        public void Update(string name, string description, long price, string category, string provider, int unity)
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
