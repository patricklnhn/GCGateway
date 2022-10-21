using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WinAppMariaDBTest//.MariaDBDatabase
{
    public partial class juntaContext : DbContext
    {
        public juntaContext()
        {
        }

        public juntaContext(DbContextOptions<juntaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Pop> Pops { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;pwd=root;database=junta", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.8.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => e.Zip, "index_addresses_on_zip");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Bnr)
                    .HasMaxLength(4)
                    .HasColumnName("bnr")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.Floor)
                    .HasMaxLength(20)
                    .HasColumnName("floor")
                    .HasDefaultValueSql("''")
                    .IsFixedLength()
                    .HasComment("entrance / floor / room");

                entity.Property(e => e.Gnr)
                    .HasMaxLength(4)
                    .HasColumnName("gnr")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.Room)
                    .HasMaxLength(30)
                    .HasColumnName("room")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Street)
                    .HasMaxLength(150)
                    .HasColumnName("street")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(10)
                    .HasColumnName("street_no")
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasMaxLength(8)
                    .HasColumnName("zip")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.ParentId, "index_categories_on_parent_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnType("mediumtext")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent_id");

                entity.Property(e => e.Responsible)
                    .HasMaxLength(20)
                    .HasColumnName("responsible")
                    .IsFixedLength();

                entity.Property(e => e.Sec)
                    .HasMaxLength(20)
                    .HasColumnName("sec")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(5)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .HasColumnName("fax")
                    .IsFixedLength();

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .HasColumnName("mobile")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("''")
                    .IsFixedLength();

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .HasColumnName("role")
                    .IsFixedLength();

                entity.Property(e => e.StatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("updated_by");
            });

            modelBuilder.Entity<Pop>(entity =>
            {
                entity.ToTable("pops");

                entity.HasIndex(e => e.ParentId, "index_pops_on_parent_id");

                entity.HasIndex(e => e.Monitor, "pops_monitor_index");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("int(11)")
                    .HasColumnName("address_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("'admin'");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description)
                    .HasColumnType("mediumtext")
                    .HasColumnName("description");

                entity.Property(e => e.DocUrl)
                    .HasMaxLength(80)
                    .HasColumnName("doc_url");

                entity.Property(e => e.GeoLatitude)
                    .HasPrecision(15, 10)
                    .HasColumnName("geo_latitude")
                    .HasDefaultValueSql("'0.0000000000'");

                entity.Property(e => e.GeoLongtitude)
                    .HasPrecision(15, 10)
                    .HasColumnName("geo_longtitude")
                    .HasDefaultValueSql("'0.0000000000'");

                entity.Property(e => e.Monitor)
                    .HasColumnName("monitor")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent_id");

                entity.Property(e => e.RegNumber)
                    .HasMaxLength(255)
                    .HasColumnName("reg_number");

                entity.Property(e => e.TechContactId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tech_contact_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("updated_by")
                    .HasDefaultValueSql("'admin'");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vendor_id");

                entity.Property(e => e.VesselCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vessel_category_id");

                entity.Property(e => e.VesselTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vessel_type_id");

                entity.Property(e => e.VpnId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vpn_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
