using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
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
             await _productRepository.Create(product);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task GetProductId(int id)
        {
            await _productRepository.GetById(id);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
