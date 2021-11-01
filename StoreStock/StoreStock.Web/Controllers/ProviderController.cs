using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using System.Threading.Tasks;

namespace StoreStock.Web.Controllers
{
    public class ProviderController : BaseController
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpPost("provider")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProvider([FromBody] Provider provider)
        {
            await _providerService.CreateProvider(provider);

            return Ok();
        }

        [HttpPut("provider/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProvider([FromBody] Provider provider)
        {
            _providerService.Update(provider);

            return Ok();
        }

        [HttpGet("providerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProviderById([FromBody] int id)
        {
            await _providerService.GetProviderId(id);

            return Ok();
        }

        [HttpGet("getAllProvider")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProvider()
        {
            await _providerService.GetAll();

            return Ok();
        }
    }
}
