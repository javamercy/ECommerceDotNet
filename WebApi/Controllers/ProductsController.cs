using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            await _productService.AddAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}