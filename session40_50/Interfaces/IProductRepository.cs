using session40_50.Models;

namespace session40_50.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        // bước 1: define new function in interface
        Task<Product> GetProductByIdAsync(int id);

        //  define function CreateProductAsync
        Task<Product> CreateProductAsync(Product product);

        //  define function UpdateProductAsync
        Task<Product> UpdateProductAsync(int id, Product product);

        //  define function DeleteProductAsync
        Task<bool> DeleteProductAsync(int ind);
    }
}