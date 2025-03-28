using It4see.Domain;

using Microsoft.EntityFrameworkCore;

namespace It4see.Persistence;

public class SensorsDatabaseContext : DbContext
{
    public SensorsDatabaseContext(DbContextOptions<SensorsDatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<SensorCategory> SensorCategories { get; set; }

    public DbSet<Sensor> Sensors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SensorCategory>()
            .HasMany(sensorCategory => sensorCategory.Sensors)
            .WithOne(sensor => sensor.SensorCategory)
            .HasForeignKey(sensor => sensor.SensorCategoryId);
    }
}