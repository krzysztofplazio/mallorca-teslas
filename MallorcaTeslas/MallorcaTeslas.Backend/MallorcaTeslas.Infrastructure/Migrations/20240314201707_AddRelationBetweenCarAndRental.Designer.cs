﻿// <auto-generated />
using System;
using MallorcaTeslas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MallorcaTeslas.Infrastructure.Migrations
{
    [DbContext(typeof(MallorcaTeslasDatabaseContext))]
    [Migration("20240314201707_AddRelationBetweenCarAndRental")]
    partial class AddRelationBetweenCarAndRental
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChargingMinutes")
                        .HasColumnType("integer");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("Power")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<int>("Range")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleOdometer")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.CarOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("OfferId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("OfferId");

                    b.ToTable("CarOffer");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PricePerDay")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<decimal>("PricePerMonth")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.Property<int>("RangeLimit")
                        .HasColumnType("integer");

                    b.Property<int>("RentDays")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BorrowPlaceId")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OfferId")
                        .HasColumnType("integer");

                    b.Property<int>("ReturnPlaceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(14, 2)
                        .HasColumnType("numeric(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("BorrowPlaceId");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OfferId");

                    b.HasIndex("ReturnPlaceId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.CarOffer", b =>
                {
                    b.HasOne("MallorcaTeslas.Core.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MallorcaTeslas.Core.Models.Offer", null)
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Customer", b =>
                {
                    b.HasOne("MallorcaTeslas.Core.Models.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("MallorcaTeslas.Core.Models.Customer", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Rental", b =>
                {
                    b.HasOne("MallorcaTeslas.Core.Models.Place", "BorrowPlace")
                        .WithMany("Borrows")
                        .HasForeignKey("BorrowPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MallorcaTeslas.Core.Models.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MallorcaTeslas.Core.Models.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MallorcaTeslas.Core.Models.Offer", "Offer")
                        .WithMany("Rentals")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MallorcaTeslas.Core.Models.Place", "ReturnPlace")
                        .WithMany("Returns")
                        .HasForeignKey("ReturnPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BorrowPlace");

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("Offer");

                    b.Navigation("ReturnPlace");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Car", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Customer", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Offer", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.Place", b =>
                {
                    b.Navigation("Borrows");

                    b.Navigation("Returns");
                });

            modelBuilder.Entity("MallorcaTeslas.Core.Models.User", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
