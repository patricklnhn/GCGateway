using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class Entities : DbContext
    {
        public DbSet<ExternalAPIs>? ExternalAPs { get; set; }
        public DbSet<TypeOfReturn>? TypeOfReturn { get; set; }
        public DbSet<APIParameters>? APIParameters { get; set; }

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
