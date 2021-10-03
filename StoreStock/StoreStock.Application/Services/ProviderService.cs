using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System.Collections;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task CreateProvider(Provider provider)
        {
            await _providerRepository.Create(provider);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _providerRepository.GetAll();
        }

        public async Task GetProviderId(int id)
        {
            await _providerRepository.GetById(id);
        }

        public void Update(Provider provider)
        {
            _providerRepository.Update(provider);
        }
    }
}
