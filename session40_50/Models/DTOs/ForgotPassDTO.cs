
using System.ComponentModel.DataAnnotations;

namespace session40_50.Models.DTOs {
    public class ForgotPassDTO {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email {get; set;} = string.Empty;
    }
}