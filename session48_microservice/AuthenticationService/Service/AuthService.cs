using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using AuthenticationService.Data;
using AuthenticationService.DTOs;
using AuthenticationService.Models;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Service {
    public class AuthService {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(AuthDbContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory) {
            _context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AuthResponse> Register(RegisterDTO registerDTO) {
            if(await _context.Users.AnyAsync(u => u.Email ==registerDTO.Email)) {
                throw new Exception("Email already exists");
            }

            var user = new User {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                PasswordHash = registerDTO.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // send email welcome -> call API Email service
            var client = _httpClientFactory.CreateClient("EmailService");
            await client.PostAsJsonAsync("api/Email/welcome", new {
                Email=user.Email,
                Username=user.Username
            });

            return new AuthResponse {
                Token = "test",
                Username=user.Username,
                Email=user.Email
            };
        }
    }
}