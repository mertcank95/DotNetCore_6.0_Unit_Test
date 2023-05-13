using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IServiceManager _service;

        public ProductController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProducts()
        {
          return await _service.ProductService.GetAllProductsAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProductAsync([FromRoute(Name = "id")] int id)
        {
            var product = await _service.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            var product = await _service.ProductService.CreateProductAsync(productDto);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneProductAsync(int id,ProductDto productDto)
        {
            await _service.ProductService.UpdateProductAsync(id, productDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProduct([FromRoute(Name = "id")] int id)
        {
            await _service.ProductService.DeleteProductAsync(id);
            return NoContent();
        }

    }
}