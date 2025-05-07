
using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Data {
    public class AuthDbContext: DbContext{
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options){}

        public DbSet<User> Users {get; set;}
    }
}