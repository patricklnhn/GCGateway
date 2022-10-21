using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProduktDatabase
{

    public class Entities : DbContext
    {
        public DbSet<Component> Components { get; set; }
        public DbSet<BusinesService> BusinesServices { get; set; }
        public DbSet<ComponentCost> ComponentCosts { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<OptionsCosts> OptionsCosts { get; set; }
        public DbSet<OptionsPerService> OptionsPerServices { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ServicesComponents> ServicesComponents { get; set; }
        public DbSet<ServicesCostAndIncome> ServicesCostAndIncome { get; set; }


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