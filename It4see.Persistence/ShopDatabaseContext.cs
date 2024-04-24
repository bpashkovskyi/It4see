using It4see.Domain;

using Microsoft.EntityFrameworkCore;

namespace It4see.Persistence;

public class ShopDatabaseContext : DbContext
{
    public ShopDatabaseContext(DbContextOptions<ShopDatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.CategoryId);
    }
}