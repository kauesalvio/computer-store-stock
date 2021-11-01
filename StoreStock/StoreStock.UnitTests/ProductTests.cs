using Bogus;
using FizzWare.NBuilder;
using NSubstitute;
using StoreStock.Application.Services;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace StoreStock.UnitTests
{
    public class ProductTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly Product _defaultProduct;
        private readonly Faker _faker;
        private readonly int _defaultId;
        private readonly string _defaultName;
        private readonly string _defaultDescription;
        private readonly string _defaultCategry;
        private readonly long _defaultPrice;
        private readonly Provider _defaultProvider;

        public ProductTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _productService = new ProductService(_productRepository);

            _faker = new Faker();
            _defaultId = 1;
            _defaultName = _faker.Random.Word();
            _defaultDescription = _faker.Random.Word();
            _defaultCategry = _faker.Random.Word();
            _defaultPrice = _faker.Random.Long();

            _defaultProvider = Builder<Provider>
                .CreateNew()
                .Build();

            _defaultProduct = Builder<Product>
                .CreateNew()
                .With(p => p.Id, _defaultId)
                .With(p => p.Name, _defaultName)
                .With(p => p.Description, _defaultDescription)
                .With(p => p.Category, _defaultCategry)
                .With(p => p.Provider, _defaultProvider)
                .With(p => p.Price, _defaultPrice)
                .With(p => p.IsActive, true)
                .Build();
        }

        [Fact]
        public async Task Should_create_product()
        {
            await _productService.CreateProduct(_defaultProduct);

            await _productRepository
                .Received(1)
                .Create(Arg.Is<Product>(x => x.Id == _defaultId && 
                                        x.Name == _defaultName &&
                                        x.Description == _defaultDescription &&
                                        x.Category == _defaultCategry &&
                                        x.Provider == _defaultProvider &&
                                        x.Price == _defaultPrice &&
                                        x.IsActive));
        }
    }
}
