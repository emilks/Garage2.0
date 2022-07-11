using System;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParkedVehicle>().HasData(
              new ParkedVehicle { Id = 1, Type = VehicleType.Motorcycle, RegNr = "ABC123", Color = "Red", Brand = "Ford", Model = "2", NrOfWheels = 4 },
              new ParkedVehicle { Id = 2, Type = VehicleType.Car, RegNr = "DEF234", Color = "Blue", Brand = "Ford", Model = "2", NrOfWheels = 4},
              new ParkedVehicle { Id = 3, Type = VehicleType.Boat, RegNr = "GHI345", Color = "Green", Brand = "Ford", Model = "2", NrOfWheels = 4 },
              new ParkedVehicle { Id = 4, Type = VehicleType.Motorcycle, RegNr = "JKL456", Color = "Yellow", Brand = "Ford", Model = "2", NrOfWheels = 4}

            );
        }


    }
}
