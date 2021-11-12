using FluentAssertions;
using NSubstitute;
using StoreStock.Application.Models.Provider;
using StoreStock.Application.Services;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StoreStock.UnitTests
{
    public class ProviderTests
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IProviderService _providerService;

        public ProviderTests()
        {
            _providerRepository = Substitute.For<IProviderRepository>();
            _providerService = new ProviderService(_providerRepository);
        }

        [Fact]
        public async Task Should_create_provider()
        {
            var request = new Provider();

            await _providerService.CreateProvider(request);

            await _providerRepository
                .Received(1)
                .Create(Arg.Is<Provider>(x => x.Id == request.Id &&
                                        x.Name == request.Name &&
                                        x.Cpf == request.Cpf &&
                                        x.Cnpj == request.Cnpj &&
                                        x.SocialContract == request.SocialContract));
        }

        [Fact]
        public async Task Should_get_all()
        {
            await _providerService.GetAll();

            await _providerRepository
                .Received(1).GetAll();
        }
    }
}
