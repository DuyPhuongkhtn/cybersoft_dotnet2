using session40_50.Interfaces;
using session40_50.Models.DTOs;
using session40_50.Models;

namespace session40_50.Services {
    public class ProductService: IProductService {
        private readonly IProductRepository _productRepository;

        // constructor
        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync() {
            var products = await _productRepository.GetAllProductsAsync();

            // convert từ entity sang DTO
            return products.Select(p => MapToProductResponseDTO(p));
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id) {
            var product = await _productRepository.GetProductByIdAsync(id);
            // convert từ entity sang DTO
            return MapToProductResponseDTO(product);
        }

        // define function MapToProductResponseDTO
        // input: Product entity
        // output: ProductResponseDTO
        private ProductResponseDTO MapToProductResponseDTO(Product product) {
            return new ProductResponseDTO {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                Name=product.Name,
                Price=product.Price,
                OriginalPrice=product.OriginalPrice,
                Discount=product.Discount,
                Stock=product.Stock,
                Sold=product.Sold,
                Rating=product.Rating,
                ReviewCount=product.ReviewCount
            };
        }
    }
}