
using session40_50.Models;
using session40_50.Models.DTOs;

namespace session40_50.Interfaces {
    public interface IUserService {
        Task<User>CreateUserAsync(UserDTO user);
        Task<User?> VerifyEmailAsync(string token);

        Task<string> LoginAsync(LoginDTO loginDTO);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> ForgotPassword(string email);

        Task<User?> ResetPasswordAsync(ResetPassDTO resetPassDTO);
    }
}