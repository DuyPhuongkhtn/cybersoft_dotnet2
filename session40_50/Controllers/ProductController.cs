using Microsoft.AspNetCore.Mvc;
using session40_50.Models;
using session40_50.Interfaces;
using session40_50.Models.DTOs;

namespace session40_50.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase {
        private readonly IProductService _productsService;

        public ProductController(IProductService productService) {
            _productsService = productService;
        }

        // define API GetAllProducts
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllProducts() {
            var products = await _productsService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductById(int id) {
            var product = await _productsService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }
}