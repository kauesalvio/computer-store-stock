using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System.Collections;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(Product product)
        {
            if (product is null)
                return;

             await _productRepository.Create(product);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task GetProductById(int id)
        {
            await _productRepository.GetById(id);
        }

        public void Update(Product product)
        {
            if (product is null)
                return;

            _productRepository.Update(product);
        }
    }
}
