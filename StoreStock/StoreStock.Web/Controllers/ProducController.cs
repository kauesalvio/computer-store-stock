using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using System.Threading.Tasks;

namespace StoreStock.Web.Controllers
{
    [Route("[controller]")]
    public class ProducController : BaseController
    {
        public readonly IProductService _productService;

        public ProducController(IProductService gateService)
        {
            _productService = gateService;
        }

        [HttpPost("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProduct(product);

            return Ok();
        }

        [HttpPut("product/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            _productService.Update(product);

            return Ok();
        }

        [HttpGet("productById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromBody] int id)
        {
            await _productService.GetProductById(id);

            return Ok();
        }

        [HttpGet("getAllProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProduct()
        {
            await _productService.GetAll();

            return Ok();
        }
    }
}
