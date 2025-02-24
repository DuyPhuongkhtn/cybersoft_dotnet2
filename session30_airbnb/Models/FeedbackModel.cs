using System.ComponentModel.DataAnnotations;

public class FeedbackModel {
    [Required(ErrorMessage = "Please enter first name")]
    public string FirstName {get; set;}

    public double Cleniness {get; set;} = 5;
}