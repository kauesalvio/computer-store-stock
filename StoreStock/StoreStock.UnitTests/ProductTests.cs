using Bogus;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using StoreStock.Application.Models.Product;
using StoreStock.Application.Services;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StoreStock.UnitTests
{
    public class ProductTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _productService = new ProductService(_productRepository);
        }

        [Fact]
        public async Task Should_create_product()
        {
            var request = new ProductRequestModel();

            await _productService.CreateProduct(request);

            await _productRepository
                .Received(1)
                .Create(Arg.Is<Product>(x => x.Id == request.Id &&
                                        x.Name == request.Name &&
                                        x.Description == request.Description &&
                                        x.Category == request.Category &&
                                        x.Provider == request.Provider &&
                                        x.Price == request.Price));
        }

        [Fact]
        public async Task Should_throw_exception_when_try_create_product()
        {
            var mensagemDeErroEsperada = "Preencha corretamente os campos para cadastrar um produto.";

            Func<Task> func = () => _productService.CreateProduct(null);

            await func.Should().ThrowAsync<Exception>().WithMessage(mensagemDeErroEsperada);
        }

        [Fact]
        public async Task Should_get_all()
        {
            await _productService.GetAllProducts();

            await _productRepository
                .Received(1).GetAll();
        }
    }
}
