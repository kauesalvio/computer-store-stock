using StoreStock.Application.Models.Product;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task CreateProduct(ProductRequestModel request)
        {
            if (request is null)
            {
                throw new Exception($"Preencha corretamente os campos para cadastrar um produto.");
            }

            var product = ProductMapping.MapProductRequestForProduct(request);

            await _productRepository.Create(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await CheckIfProductExist(id);

            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            await CheckIfProductExist(product.Id);

            _productRepository.Update(product);
        }

        public async Task DeleteProduct(int id)
        {
            var productDb = await _productRepository.GetById(id);
            if (productDb is null)
                throw new Exception($"O Produto com o id {id} não foi encontrado!");

            _productRepository.Delete(productDb);
        }

        private async Task<Product> CheckIfProductExist(int id)
        {
            var productDb = await _productRepository.GetById(id);
            if (productDb is null)
            {
                throw new Exception($"O Produto com o id {id} não foi encontrado!");
            }

            return productDb;
        }
    }
}
