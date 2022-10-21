﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OffersAndServicesDatabase;

#nullable disable

namespace OffersAndServicesDatabase.Migrations
{
    [DbContext(typeof(Entities))]
    [Migration("20220811075016_UpdateedColSAndAnnotations")]
    partial class UpdateedColSAndAnnotations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OffersAndServicesDatabase.ComponentInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceInstanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceInstanceId");

                    b.ToTable("ComponentInstances");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.MercantileStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("MercantileStatuses");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.Options", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MRC")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("OTC")
                        .HasColumnType("int");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.OptionsChosen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("OptionValueId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceInstanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("OptionValueId");

                    b.HasIndex("ServiceInstanceId");

                    b.ToTable("OptionsChosen");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.OptionValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("OptionValues");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusinesServiceID")
                        .HasColumnType("int");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("RegisteredBy")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.ServiceInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OrgNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RedundantServiceLocation")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceContactId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceContactName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("ServiceLocation")
                        .HasColumnType("int");

                    b.Property<int>("ServiceNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("ServiceInstances");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.ServiceInstanceCostAndIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MRC")
                        .HasColumnType("int");

                    b.Property<int>("MRR")
                        .HasColumnType("int");

                    b.Property<int>("OTC")
                        .HasColumnType("int");

                    b.Property<int>("OTR")
                        .HasColumnType("int");

                    b.Property<int>("ServiceInstanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceInstanceId");

                    b.ToTable("ServiceInstancesCostAndIncome");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.TechnicalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TS")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("TechnicalStatuses");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.ComponentInstance", b =>
                {
                    b.HasOne("OffersAndServicesDatabase.ServiceInstance", "ServiceInstance")
                        .WithMany()
                        .HasForeignKey("ServiceInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceInstance");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.OptionsChosen", b =>
                {
                    b.HasOne("OffersAndServicesDatabase.Options", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OffersAndServicesDatabase.OptionValues", "OptionValue")
                        .WithMany()
                        .HasForeignKey("OptionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OffersAndServicesDatabase.ServiceInstance", "ServiceInstance")
                        .WithMany()
                        .HasForeignKey("ServiceInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("OptionValue");

                    b.Navigation("ServiceInstance");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.OptionValues", b =>
                {
                    b.HasOne("OffersAndServicesDatabase.Options", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.ServiceInstance", b =>
                {
                    b.HasOne("OffersAndServicesDatabase.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("OffersAndServicesDatabase.ServiceInstanceCostAndIncome", b =>
                {
                    b.HasOne("OffersAndServicesDatabase.ServiceInstance", "ServiceInstance")
                        .WithMany()
                        .HasForeignKey("ServiceInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceInstance");
                });
#pragma warning restore 612, 618
        }
    }
}
