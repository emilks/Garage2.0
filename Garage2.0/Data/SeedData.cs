using Bogus;
using Garage2._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Garage2._0.Data
{
    public class SeedData
    {
       private static Faker faker = default!;
        public static async Task InitVehicleTypeAsync(Garage2_0Context db)
        {
            if (await db.VehicleType.AnyAsync()) return;

            var vehicleTypes = GenerateVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);

            //var parkingSpaces = GenerateParkingSpaces();
            // await db.AddRangeAsync(parkingSpaces);
          

            await db.SaveChangesAsync();
        }

        //private static IEnumerable<VehicleTypeEntity> GetParkingSpots()
        //{
       
        //}

        private static IEnumerable<VehicleTypeEntity> GenerateVehicleTypes()
        {
            var vehicleTypes = new List<VehicleTypeEntity>
         {
             new VehicleTypeEntity{ Category = "Car", Size = 1},
             new VehicleTypeEntity{ Category = "Truck", Size = 3},
             new VehicleTypeEntity{ Category = "Boat", Size = 2},
             new VehicleTypeEntity{ Category = "Airplane", Size = 5}
         };

            return vehicleTypes;
        }
    }
}
