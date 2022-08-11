﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Models;

namespace Garage2._0.Data
{
    public class Garage2_0Context : DbContext
    {
        public Garage2_0Context (DbContextOptions<Garage2_0Context> options)
            : base(options)
        {
        }

        public DbSet<Garage2._0.Models.ParkedVehicle>? ParkedVehicle { get; set; }


        


        public DbSet<Garage2._0.Models.Member>? Member { get; set; }


        public DbSet<Garage2._0.Models.Vehicle>? Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, FirstName = "John", LastName = "Doe", PerNr = "123456" },
                new Member { Id = 2, FirstName = "Jane", LastName = "Doe", PerNr = "123" }
            );
            modelBuilder.Entity<VehicleTypeEntity>().HasData(
                new VehicleTypeEntity { Id = 1, Category = "Car", Size = 1 }

                //new Vehicle { Id = 1, RegNr = "AAA111", Color = "Red", Brand = "Volvo", Model = "V20", NrOfWheels = 4, MemberId = 1, VehicleTypeEntityId = 1 },
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, RegNr = "AAA111", Color = "Red", Brand = "Volvo", Model = "V20", NrOfWheels = 4, MemberId = 1, VehicleTypeEntityId = 1}
            );

            modelBuilder.Entity<ParkingSpace>().HasData(
                new ParkingSpace { Id = 1}
            );
        }
    }
}
