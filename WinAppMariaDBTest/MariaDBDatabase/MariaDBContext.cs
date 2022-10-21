using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.CData.MariaDB;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pomelo.EntityFrameworkCore;

namespace MariaDBDatabase
{ 

public class MariaDBContext : DbContext
{
    public MariaDBContext() { }
        //public DbSet<pops> pops { get; set; }

        //protected override void OnConfiguring(MySqlDbContextOptionsBuilder optionsBuilder)
        //{
        //    if(!optionsBuilder.)
        //}

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            
        
        // To remove the requests to the Migration History table
        Database.SetInitializer<MariaDBContext>(null);
        // To remove the plural names   
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
}
}