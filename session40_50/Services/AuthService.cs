
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;

namespace session40_50.Services {
    public class AuthService: IUserService {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IEmailService emailService, IConfiguration configuration){
            _userRepository = userRepository;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<User>CreateUserAsync(UserDTO user) {
            // check if user exists - để sau

            Console.WriteLine(user.Email);
            Console.WriteLine(user.Password);

            // mã hóa password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // tạo token để verify new account
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            // tạo link verify new account
            // link này là API để verify new account
            var baseUrl = _configuration["AppSettings:BaseUrl"];
            var verifyUrl = $"{baseUrl}/verify-email?token={token}";

            // create new user
            var newUser = new User {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                VerificationToken=token,
                IsEmailVerified=false // default là false để khi tạo mới thì chưa verify email
            };

            await _userRepository.CreateUserAsync(newUser);

            // send email to new user
            var emailBody = $@"
                <h1> Welcome to our website! </h1>
                <p> You have successfully registered to our website. </p>
                <p> Your username is: {user.Email} </p>
                <a href='{verifyUrl}'>Verify your email</a>
            ";

            await _emailService.SendEmailAsync(user.Email, "Welcome", emailBody);
            return newUser;
        }

        public async Task<User?> VerifyEmailAsync(string token) {
            return await _userRepository.GetUserByVerificationTokenAsync(token);
        }

        public async Task<string?> LoginAsync(LoginDTO loginDTO) {
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user == null) {
                return null;
            }
            // kiểm tra password
            // Verify có 2 tham số
            // tham số 1 là password được nhập từ client
            // tham số 2 là password được mã hóa trong DB
            // return là true nếu password nhập đúng, ngược lại false
            if(!BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password)) {
                Console.WriteLine("Password không đúng");
                return null;
            }

            // kiểm tra email đã được verify chưa
            if(!user.IsEmailVerified) {
                return null;
            }
            var token = "test-token";
            return token;
        }
    }
}