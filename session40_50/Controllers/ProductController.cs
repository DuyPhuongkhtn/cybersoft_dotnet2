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

        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> CreateProduct(ProductRequestDTO productDTO){
            // validate model
            // 2xx: 200 (Ok), 201 (CREATED),..... => success
            // 4xx: 400 (Bad request), 401(unauthorized), 403(forbidden), 404(not found), 409(conflict), 413(request entity too large), 415(unsupported media type), 422(unprocessable entity
            // => client error
            // 5xx: 500(internal server ) => server error
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var createdProduct = await _productsService.CreateProductAsync(productDTO);
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> UpdateProduct(int id, ProductRequestDTO productDTO) {
            // Lưu ý: vì bước kiểm tra dữ liệu đã dùng ở layer service nên không cần kiểm tra ở layer controller nữa
            var  updatedProduct = await _productsService.UpdateProductAsync(id, productDTO);

            if(updatedProduct == null) {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id) {
            var deletedProduct = await _productsService.DeleteProductAsync(id);
            if(!deletedProduct) {
                return NotFound();
            }

            return NoContent();
        }
    }
}