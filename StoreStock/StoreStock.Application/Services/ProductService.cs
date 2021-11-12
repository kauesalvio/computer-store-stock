﻿using StoreStock.Application.Models.Product;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICsvService<ProductResponseModel> _csvService;

        public ProductService(IProductRepository productRepository, ICsvService<ProductResponseModel> csvService)
        {
            _productRepository = productRepository;
            _csvService = csvService;
        }

        public async Task CreateProduct(ProductRequestModel request)
        {
            if (request is null)
                throw new Exception($"Preencha corretamente os campos para cadastrar um produto.");

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

        public async Task UpdateProduct(int id, ProductRequestModel request)
        {
            var product = await CheckIfProductExist(id);

            product.Update(request.Name, request.Description, request.Price, request.Category, request.Provider, request.Unity);

            _productRepository.Update(product);
        }

        public async Task DeleteProduct(int id)
        {
            var productDb = await CheckIfProductExist(id);

            _productRepository.Delete(productDb);
        }

        public async Task<byte[]> CriarExcel()
        {
            var products = await _productRepository.GetAll();

            List<ProductResponseModel> productsExport = products.Select(p => new ProductResponseModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Provider = p.Provider,
                Price = p.Price,
                Unity = p.Unity
            }).ToList();

            return _csvService.ExportarCsv(productsExport);
        }

        private async Task<Product> CheckIfProductExist(int id)
        {
            var productDb = await _productRepository.GetById(id);
            if (productDb is null)
                throw new ArgumentException($"O Produto com o id {id} não foi encontrado!");

            return productDb;
        }
    }
}
