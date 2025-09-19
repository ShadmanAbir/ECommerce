using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Services;
using ECommerce.API.ViewModels;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductViewModel model)
        {
            var created = await _productService.CreateProductAsync(model);
            return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductViewModel model)
        {
            if (id != model.ProductId) return BadRequest();

            var updated = await _productService.UpdateProductAsync(id, model);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
