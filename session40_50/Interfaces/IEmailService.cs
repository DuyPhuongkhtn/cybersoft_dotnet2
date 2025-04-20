
namespace session40_50.Interfaces {
    public interface IEmailService {
        Task SendEmailAsync(string to, string subject, string body);
    }
}