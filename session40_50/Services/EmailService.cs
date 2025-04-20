
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using session40_50.Interfaces;

namespace session40_50.Services {
    public class EmailService: IEmailService {
        // biến load các biến môi trường từ file appsettings.json
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body) {
            // b1: khởi tạo email mime
            var email = new MimeMessage();

            // b2: setup thông tin người gửi (FROM)
            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:From"]));

            // b3: setup infor người nhận (TO)
            email.To.Add(MailboxAddress.Parse(to));

            // b4: setup thông tin chủ đề (Subject)
            email.Subject = subject;

            // b5: setup nội dung email (Body)
            var builder = new BodyBuilder {
                HtmlBody = body
            };

            email.Body = builder.ToMessageBody();

            // b6: thiết lập SMTP client
            var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_configuration["EmailSettings:SmtpServer"],
            int.Parse(_configuration["EmailSettings:Port"]),
            SecureSocketOptions.StartTls);

            await smtpClient.AuthenticateAsync(_configuration["EmailSettings:Username"],
            _configuration["EmailSettings:Password"]);

            // b7: gửi email
            await smtpClient.SendAsync(email);

            // b8: đóng kết nối
            await smtpClient.DisconnectAsync(true);
        }
    }
}