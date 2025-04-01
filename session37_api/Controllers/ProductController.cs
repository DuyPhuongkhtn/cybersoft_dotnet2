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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string? search=null,
            [FromQuery] int page=1,
            [FromQuery] int pageSize=10
        ) {
            // lấy header
            var userAgent = Request.Headers["User-Agent"].ToString();

            // log header
            Console.WriteLine($"User-Agent: {userAgent}");

            // query
            // cách 1: dùng AsQueryable() => recommend
            // lọc dữ liệu
            // phân trang
            // tìm kiếm
            // tối ưu hiệu suất
            // giảm tải cho database
            // Explain:
            // - có cơ chế cache built-in
            // - lazy loading
            // AsQueryable() sẽ đợi user truyền các điều kiện filter
            // và phân trang, sau đó mới connect tới database
            // để lấy dữ liệu cần thiết

            var query = _context.Products.AsQueryable();

            // cách 2: dùng FirstOrDefaultAsync()
            // kém hiệu quả vì hàm này sẽ connect tới database
            // và lấy tất cả dữ liệu về, rồi sau đó mới filter dữ liệu

            // cách 3: Where().FirstOrDefaultAsync()
            // SELECT * FROM Product WHERE Id = @id

            // áp dụng các điều kiện tìm kiếm
            if(!string.IsNullOrEmpty(search)) {
                // SELECT * FROM Products
                // WHERE Name like '%search%'
                query = query.Where(p => p.Name.Contains(search));
            }

            // phân trang
            var totalItems = await query.CountAsync();
            // vì parameter của hàm Ceiling có kiểu là decimal
            // => phải ép kiểu về số thực
            // vì datatype của kết quả hàm Ceiling có kiểu là double
            // => ép kiểu về int để phù hợp với totalPage
            var totalPages = (int)Math.Ceiling(totalItems/(double)pageSize);

            var products = await query
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();


            // return await _context.Products.ToListAsync();
            return Ok(new {
                Data=products,
                Pagination=new {
                    TotalItem=totalItems,
                    TotalPages=totalPages,
                    CurrentPage=page,
                    PageSize=pageSize
                }
            });
        }

        // define API POST
        [HttpPost] // đánh dấu đây là API POST
        public async Task<ActionResult<Product>> CreateProduct(Product product) {
            // kiểm tra input
            if(!ModelState.IsValid) {
                return BadRequest(new {
                    Message = "Validation failed",
                    Errors = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                });
            }

            // kiểm tra tên sản phẩm đã tồn tại chưa
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Name == product.Name);
            
            if(existingProduct != null) {
                return BadRequest(new {
                    Message = "Product name already exists"
                });
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new {
                Message = "Product created successfully",
                Data = product
            });
        }

        // define API detail product
        [HttpGet("{id}")] // define biến parameter tên là id
        public async Task<ActionResult<Product>> GetProductById(int id) {
            // cách 1: dùng FindAsync() => recommened
            // tìm kiếm theo primary key (default index) nên việc truy xuất nhanh hơn
            // cơ chế cache built-in
            var product = await _context.Products.FindAsync(id);

            if(product == null) {
                return NotFound(new {
                    Message = "Product not found"
                });
            }

            return product;
        }

        // define API PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product){
            // kiểm tra id từ parameter với id từ body
            if (id != product.Id) {
                return BadRequest(new {
                    Message = "Id mismatch"
                });
            }
            // kiểm tra giá trị các field trong object
            if(!ModelState.IsValid) {
                return BadRequest(new {
                    Message = "Validation failed",
                    Errors = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                });
            }

            // kiểm tra product muốn update có trong database hay không
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null) {
                return NotFound(new {
                    Message = "Product not found"
                });
            }

            // update product
            // chuyển entity Product về mode update
            // _context.Entry(product).State = EntityState.Modified;
            var value = _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}