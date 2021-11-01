using StoreStock.Domain.Entities;

namespace StoreStock.Application.Models.Product
{
    public abstract class ProductBaseModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public long Price { get; private set; }
        public string Category { get; private set; }
        public int Provider { get; private set; }
        public int Unity { get; private set; }
    }
}
