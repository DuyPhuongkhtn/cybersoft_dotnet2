using Microsoft.EntityFrameworkCore;

// using session37_api.Models;

public class ApplicationDbContext: DbContext {
    // constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

    public DbSet<Product> Products {get; set;}
}

