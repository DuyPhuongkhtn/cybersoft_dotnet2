using System.ComponentModel.DataAnnotations;

public class ContactModel {
    [Required(ErrorMessage = "Please enter your name")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    public string FullName {get; set;} = string.Empty;

    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email {get; set;} = string.Empty;

    [Required(ErrorMessage = "Please enter your phone number")]
    [RegularExpression(@"^(\d{10,12})$", ErrorMessage = "Please enter a valid phone number")]
    public string PhoneNumber {get; set;} = string.Empty;
}