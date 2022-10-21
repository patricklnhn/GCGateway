
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PointDatabase
{
    public class Entities : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Fylke> Fylke { get; set; }
        public DbSet<HealthRegion> HealthRegions { get; set; }
        public DbSet<Kommune> Kommune { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Poststed> Poststed { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //legger til constraints
            modelBuilder.Entity<Location>(e =>
            {
                e.HasIndex(l => l.OrgNumber).IsUnique();
            });

            modelBuilder.Entity<Vehicle>(e =>
            {
                e.HasIndex(f => f.Registration).IsUnique();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("CoreWebAPIConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


    }
}
