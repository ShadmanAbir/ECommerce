using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public IActionResult Post(ProductViewModel productVM)
        {
            return Ok(_productService.CreateProduct(productVM));
        }

        [HttpPut]
        public IActionResult Put(ProductViewModel productVM)
        {
            return Ok(_productService.UpdateProduct(productVM));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAllProduct());
        }

        [HttpGet("{ProductID}")]
        public IActionResult GetByID(int ProductID)
        {
            return Ok(_productService.GetProductByID(ProductID));
        }
    }
}
