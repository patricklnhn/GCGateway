using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;


namespace GlobalConnectDataDB
{
    public class Entities : DbContext
    {

       
        public DbSet<Junta2GcConnections> Junta2GcConnections { get; set; }
        public DbSet<GcCoverageCheck> GcCoverageCheck { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
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
