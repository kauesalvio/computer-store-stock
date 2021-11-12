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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequestModel request)
        {
            await _productService.CreateProduct(request);

            return Created(string.Empty, "Produto criado com Sucesso!");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductRequestModel request)
        {
            await _productService.UpdateProduct(id, request);

            return Ok("Produto atualizado com Sucesso!");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductById(id);

            return Ok(product);
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
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet, Route("export")]
        public async Task<FileResult> ConsultarCsv()
        {
            var table = await _productService.CriarExcel();

            return File(table, "text/csv", "ExportarExcel.csv");
        }
    }
}
