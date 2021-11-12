namespace StoreStock.Application.Models.Product
{
    public abstract class ProductBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get;  set; }
        public long Price { get;  set; }
        public string Category { get;  set; }
        public string Provider { get;  set; }
        public int Unity { get;  set; }
    }
}
