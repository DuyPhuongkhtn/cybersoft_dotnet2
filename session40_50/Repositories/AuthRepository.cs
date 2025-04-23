
using Microsoft.EntityFrameworkCore;
using session40_50.Data;
using session40_50.Interfaces;
using session40_50.Models;

namespace session40_50.Repositories {
    public class AuthRepository: IUserRepository {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(User user) {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByVerificationTokenAsync(string token) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if(user == null) {
                return null;
            }

            user.IsEmailVerified = true;
            user.VerificationToken = null;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email) {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}