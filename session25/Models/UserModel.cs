using System.ComponentModel.DataAnnotations;

public class UserModel {
    [Required(ErrorMessage = "Please input UserName")]
    [MinLength(8, ErrorMessage = "UserName must be at least 8 characters")]
    [MaxLength(20, ErrorMessage = "UserName must be at most 20 characters")]
    public string UserName {get; set;}=string.Empty;

    [Required(ErrorMessage = "Please input Password")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password {get; set;}=string.Empty;

    public string FullName {get; set;} = string.Empty;

    public string Gender {get; set;} = "Female";

    public string Country {get; set;} = "Vietnam";

    [Required(ErrorMessage = "Please input phone number")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone number must be 10-12 digits")]
    public string Phone {get; set;} = string.Empty;
}