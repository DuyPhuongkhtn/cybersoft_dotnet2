using Microsoft.EntityFrameworkCore;
using session37_api.Models;

// using session37_api.Models;
namespace session37_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        // constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}