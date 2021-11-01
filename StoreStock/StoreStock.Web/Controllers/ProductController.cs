using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using System.Threading.Tasks;

namespace StoreStock.Web.Controllers
{
    public class ProductController : BaseController
    {
        public readonly IProductService _productService;

        public ProductController(IProductService gateService)
        {
            _productService = gateService;
        }

        //[HttpGet("/edu")]
        //public IActionResult Test()
        //{
        //    return Ok("Foi");
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProduct(product);

            return Created("Produto criado com Sucesso!", null);
        }

        [HttpPut("/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            await _productService.UpdateProduct(product);

            return Ok("Produto atualizado com Sucesso!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            await _productService.GetProductById(id);

            return Ok();
        }

        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            await _productService.GetAllProducts();

            return Ok();
        }
    }
}
