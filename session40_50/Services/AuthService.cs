
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;

namespace session40_50.Services {
    public class AuthService: IUserService {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository, IEmailService emailService){
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<User>CreateUserAsync(UserDTO user) {
            // check if user exists - để sau

            Console.WriteLine(user.Email);
            Console.WriteLine(user.Password);

            // create new user
            var newUser = new User {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };

            await _userRepository.CreateUserAsync(newUser);

            // send email to new user
            var emailBody = $@"
                <h1> Welcome to our website! </h1>
                <p> You have successfully registered to our website. </p>
                <p> Your username is: {user.Email} </p>
            ";

            await _emailService.SendEmailAsync(user.Email, "Welcome", emailBody);
            return newUser;
        }
    }
}