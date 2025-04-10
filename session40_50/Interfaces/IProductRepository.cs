using session40_50.Models;

namespace session40_50.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        // bước 1: define new function in interface
        Task<Product> GetProductByIdAsync(int id);
    }
}