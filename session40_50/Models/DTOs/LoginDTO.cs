using System.ComponentModel.DataAnnotations;

namespace session40_50.Models.DTOs {
    public class LoginDTO {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email {get; set;} = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password {get; set;} = string.Empty;
    }
}