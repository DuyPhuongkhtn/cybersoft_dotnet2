using System.ComponentModel.DataAnnotations;

public class FeedbackModel {
    [Required(ErrorMessage = "Please enter first name")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "Please enter last name")]
    public string LastName {get; set;}

    [Required(ErrorMessage = "Please enter email")]
    [EmailAddress(ErrorMessage = "Please enter valid email")]
    public string Email {get; set;}

    [Required(ErrorMessage = "Please enter username")]
    public string Username {get; set;}

    public double Cleniness {get; set;} = 5;
    public double Staff {get; set;} = 5;
    public double Comfort {get; set;} = 5;
    public double Value {get; set;} = 5;
    public string FeedbackText {get; set;}
}