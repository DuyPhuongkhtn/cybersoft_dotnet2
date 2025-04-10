
namespace session40_50.Models.DTOs
{
    public class ProductResponseDTO
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
