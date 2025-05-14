namespace EmailService.Services {
    public interface IEmailService {
        Task SendWelcomeEmail(string email, string username);
    }
}