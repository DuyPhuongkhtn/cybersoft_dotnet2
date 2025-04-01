using System.ComponentModel.DataAnnotations;

namespace session37_api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 99000000, ErrorMessage = "Price must be between 0 and 99,000,000")]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}