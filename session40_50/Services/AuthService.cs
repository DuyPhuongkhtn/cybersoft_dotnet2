
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
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
                IsEmailVerified=false, // default là false để khi tạo mới thì chưa verify email
                Role=user.Role
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

        // define function generate token
        private string GenerateJwtToken(User user) {
            // lấy key tạo token từ appsettings.json
            var securityKey = _configuration["Jwt:Key"];
            var formatKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credentials = new SigningCredentials(formatKey, SecurityAlgorithms.HmacSha256);

            // tạo claims (lưu những info cơ bản của user để BE verify)
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role) // truyền info Role vào claim
            };

            // tạo token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], // required
                audience: _configuration["Jwt:Audience"], // required
                claims: claims, //required
                expires: DateTime.Now.AddHours(1), // required
                signingCredentials: credentials //required
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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
            var token = GenerateJwtToken(user);
            return token;
        }

        public async Task<User?> GetUserByEmailAsync(string email) {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }

        public async Task<User?> ForgotPassword(string email) {
            var user = await GetUserByEmailAsync(email);
            if(user == null) {
                return null;
            }

            var tokenResetPassword = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            // lưu thông tin token reset vào database
            user.TokenResetPassword = tokenResetPassword;
            user.ExpiresTokenReset = DateTime.Now.AddHours(1);

            await _userRepository.UpdateUserAsync(user);
            
            // gửi email đến email của user
            _emailService.SendEmailAsync(email, "Reset password", $"Your token is: {tokenResetPassword}");

            return user;
        }

        public async Task<User?> ResetPasswordAsync(ResetPassDTO resetPassDTO) {
            Console.WriteLine($"Reset password: {resetPassDTO.ResetToken}");
            var user = await _userRepository.GetUserByResetToken(resetPassDTO.ResetToken);
            if(user == null) {
                return null;
            }

            // mã hóa password mới
            user.Password = BCrypt.Net.BCrypt.HashPassword(resetPassDTO.NewPassword);
            user.TokenResetPassword = "";
            user.ExpiresTokenReset = null;

            await _userRepository.UpdateUserAsync(user);
            return user;
        }

    }
}