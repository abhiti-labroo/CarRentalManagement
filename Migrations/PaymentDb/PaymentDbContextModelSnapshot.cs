﻿// <auto-generated />
using System;
using CarRentalManagement.PaymentService.DataAcLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentalManagement.Migrations.PaymentDb
{
    [DbContext(typeof(PaymentDbContext))]
    partial class PaymentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentalManagement.CarService.DataAcessLayer.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<decimal>("BuyCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<decimal>("RentCostPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentCostPerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentCostPerWeek")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CarId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarRentalManagement.PaymentService.DataAcLayer.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RentalId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("RentalId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Customer", b =>
                {
                    b.Property<int>("CusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CusId"), 1L, 1);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CusId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalId"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CusId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerCusId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RentalCarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalEnddate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStartdate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalRentalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RentalId");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerCusId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.RentalCar", b =>
                {
                    b.Property<int>("RentalCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalCarId"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("RentalCarPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RentalCarQuantity")
                        .HasColumnType("int");

                    b.Property<string>("RentalCarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalRentalCarAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RentalCarId");

                    b.HasIndex("CarId");

                    b.HasIndex("RentalId");

                    b.ToTable("RentalCar");
                });

            modelBuilder.Entity("CarRentalManagement.PaymentService.DataAcLayer.Models.Payment", b =>
                {
                    b.HasOne("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Rental", "Rental")
                        .WithMany()
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Rental", b =>
                {
                    b.HasOne("CarRentalManagement.CarService.DataAcessLayer.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerCusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.RentalCar", b =>
                {
                    b.HasOne("CarRentalManagement.CarService.DataAcessLayer.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Rental", "Rental")
                        .WithMany("RentalCars")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Customer", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("CarRentalManagement.RentalManagementService.DataAccessLayer.Models.Rental", b =>
                {
                    b.Navigation("RentalCars");
                });
#pragma warning restore 612, 618
        }
    }
}
