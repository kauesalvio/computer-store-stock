using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreStock.Application.Models.Product;
using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using System.Collections.Generic;
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

        [HttpGet("/edu/edu")]
        public IActionResult Test()
        {
            return Ok("Foi");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequestModel request)
        {
            await _productService.CreateProduct(request);

            return Created("Produto criado com Sucesso!", null);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            await _productService.UpdateProduct(product);

            return Ok("Produto atualizado com Sucesso!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] int id)
        {
            await _productService.GetProductById(id);

            return Ok();
        }

        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
