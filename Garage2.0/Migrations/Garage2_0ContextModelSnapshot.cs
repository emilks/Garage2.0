﻿// <auto-generated />
using System;
using Garage2._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage2._0.Migrations
{
    [DbContext(typeof(Garage2_0Context))]
    partial class Garage2_0ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Garage2._0.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            PerNr = "123456"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Doe",
                            PerNr = "123"
                        });
                });

            modelBuilder.Entity("Garage2._0.Models.Park", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("Park");
                });

            modelBuilder.Entity("Garage2._0.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicle");
                });

            modelBuilder.Entity("Garage2._0.Models.ParkingSpace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NumberSpot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkId");

                    b.ToTable("ParkingSpace");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberSpot = "A1"
                        },
                        new
                        {
                            Id = 2,
                            NumberSpot = "A2"
                        },
                        new
                        {
                            Id = 3,
                            NumberSpot = "A3"
                        },
                        new
                        {
                            Id = 4,
                            NumberSpot = "A4"
                        });
                });

            modelBuilder.Entity("Garage2._0.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("VehicleTypeEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("VehicleTypeEntityId");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Volvo",
                            Color = "Red",
                            MemberId = 1,
                            Model = "V20",
                            NrOfWheels = 4,
                            RegNr = "AAA111",
                            VehicleTypeEntityId = 1
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Mercedes",
                            Color = "Black",
                            MemberId = 1,
                            Model = "X100",
                            NrOfWheels = 4,
                            RegNr = "BBB222",
                            VehicleTypeEntityId = 1
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Ferrari",
                            Color = "White",
                            MemberId = 1,
                            Model = "E-Type",
                            NrOfWheels = 4,
                            RegNr = "CCC333",
                            VehicleTypeEntityId = 1
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Volvo",
                            Color = "Blue",
                            MemberId = 2,
                            Model = "V20",
                            NrOfWheels = 4,
                            RegNr = "DDD444",
                            VehicleTypeEntityId = 1
                        });
                });

            modelBuilder.Entity("Garage2._0.Models.VehicleTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Car",
                            Size = 1
                        });
                });

            modelBuilder.Entity("Garage2._0.Models.Park", b =>
                {
                    b.HasOne("Garage2._0.Models.Vehicle", "Vehicle")
                        .WithOne("Park")
                        .HasForeignKey("Garage2._0.Models.Park", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Garage2._0.Models.ParkingSpace", b =>
                {
                    b.HasOne("Garage2._0.Models.Park", "Park")
                        .WithMany("Spaces")
                        .HasForeignKey("ParkId");

                    b.Navigation("Park");
                });

            modelBuilder.Entity("Garage2._0.Models.Vehicle", b =>
                {
                    b.HasOne("Garage2._0.Models.Member", "Member")
                        .WithMany("Vehicles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage2._0.Models.VehicleTypeEntity", "VehicleTypeEntity")
                        .WithMany()
                        .HasForeignKey("VehicleTypeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("VehicleTypeEntity");
                });

            modelBuilder.Entity("Garage2._0.Models.Member", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Garage2._0.Models.Park", b =>
                {
                    b.Navigation("Spaces");
                });

            modelBuilder.Entity("Garage2._0.Models.Vehicle", b =>
                {
                    b.Navigation("Park");
                });
#pragma warning restore 612, 618
        }
    }
}
