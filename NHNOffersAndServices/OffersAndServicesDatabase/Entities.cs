using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OffersAndServicesDatabase
{
    public class Entities : DbContext
    {
        public DbSet<ComponentInstance> ComponentInstances { get; set; }
        public DbSet<MercantileStatus> MercantileStatuses { get; set; }  

        public DbSet<Options> Options { get; set; } 
        public DbSet<OptionsChosen> OptionsChosen { get; set; }
        public DbSet<OptionValues> OptionValues { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ServiceInstance> ServiceInstances { get; set; }
        public DbSet<ServiceInstanceCostAndIncome> ServiceInstancesCostAndIncome { get; set; }
        public DbSet<TechnicalStatus> TechnicalStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //legger til constraints
            //modelBuilder.Entity<Medlem>(e =>
            //{
            //    e.HasIndex(m => m.Orgnummer).IsUnique();
            //});

            //modelBuilder.Entity<Fartøy>(e =>
            //{
            //    e.HasIndex(f => f.Registreringsnummer).IsUnique();
            //});
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
