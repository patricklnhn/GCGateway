// <auto-generated />
using System;
using GlobalConnectDataDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GlobalConnectDataDB.Migrations
{
    [DbContext(typeof(Entities))]
    [Migration("20220915105342_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GlobalConnectDataDB.GcCoverageCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GcGabId")
                        .HasColumnType("int");

                    b.Property<string>("ResultJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GcCoverageCheck");
                });

            modelBuilder.Entity("GlobalConnectDataDB.Junta2GcConnections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GcGabId")
                        .HasColumnType("int");

                    b.Property<int>("JuntaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Junta2GcConnections");
                });
#pragma warning restore 612, 618
        }
    }
}
