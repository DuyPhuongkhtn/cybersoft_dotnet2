
namespace session40_50.Models.DTOs {
    public class UserDTO {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; // password đã được mã hóa

        public bool IsEmailVerified { get; set; } = false;

        public string? VerificationToken { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public string Role { get; set;} = "User";
    }
}