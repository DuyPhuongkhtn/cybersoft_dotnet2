using session40_50.Interfaces;
using Microsoft.EntityFrameworkCore;
using session40_50.Models;
using session40_50.Data;


namespace session40_50.Repositories {
    public class MongoRepository: IProductRepository {
        private readonly ApplicationDbContext _context;

        public MongoRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() {
            // EF Core sẽ tự động chuyển sang SQL và connect tới database
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id) {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product) {
            // tạo data cho CreatedAt và UpdatedAt
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product) {
            // lấy product từ database
            var existingProduct = await _context.Products.FindAsync(id);

            // kiểm tra nếu ko có thì trả về null
            if(existingProduct == null) {
                return null;
            }

            // nếu có thì update và return product Entity
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.UpdatedAt = DateTime.UtcNow;
            existingProduct.Description = product.Description;
            existingProduct.Discount = product.Discount;
            existingProduct.Stock = product.Stock;
            existingProduct.OriginalPrice = product.OriginalPrice;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProductAsync(int id) {
            // lấy product từ database
            var existingProduct = await _context.Products.FindAsync(id);
            if(existingProduct == null) {
                return false;
            }

            // nếu có thì xóa và return true
            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}