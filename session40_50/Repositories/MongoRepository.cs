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
    }
}