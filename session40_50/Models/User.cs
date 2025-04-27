using System.ComponentModel.DataAnnotations;

namespace session40_50.Models {
    public class User {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; // password đã được mã hóa

        public bool IsEmailVerified { get; set; } = false;

        public string? VerificationToken { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        // thêm column Role
        public string Role { get; set;} = "User";

        public string TokenResetPassword {get; set;} = string.Empty;

        public DateTime? ExpiresTokenReset {get; set;}
    }
}