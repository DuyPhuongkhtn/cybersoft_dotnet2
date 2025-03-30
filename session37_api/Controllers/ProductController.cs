using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session37_api.Data;
using session37_api.Models;

namespace session37_api.Controllers {

    // rule đặt tên file controller
    // hậu tố phải là Controller. VD: ProductController
    // [controller] => Product
    [ApiController] // thông báo cho .NET biết controller mình tự tạo
    [Route("api/[controller]")] // api/Product
    public class ProductController: ControllerBase {
        // define attribute cho đối tượng ProductController
        private readonly ApplicationDbContext _context;

        // define hàm khởi tạo - constructor
        public ProductController(ApplicationDbContext context) {
            _context = context;
        }

        // define các API
        // API GET Product
        [HttpGet] // đánh dấu đây là API GET
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {
            return await _context.Products.ToListAsync();
        }
    }
}