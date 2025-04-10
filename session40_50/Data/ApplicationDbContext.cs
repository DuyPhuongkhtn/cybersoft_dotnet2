using Microsoft.EntityFrameworkCore;
using session40_50.Models;

namespace session40_50.Data {
    public class ApplicationDbContext: DbContext {
        // constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

        // add các Model entity
        public DbSet<Product> Products { get; set; }
    }
}