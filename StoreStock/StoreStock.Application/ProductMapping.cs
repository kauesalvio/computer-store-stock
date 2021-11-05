using StoreStock.Application.Models.Product;
using StoreStock.Domain.Entities;

namespace StoreStock.Application
{
    public class ProductMapping
    {
        public static Product MapProductRequestForProduct(ProductRequestModel request)
        {
            return new Product(request.Name, request.Description, request.Price, request.Category, request.Provider, request.Unity);
        }
    }
}
