using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2._0.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Red", "2", 4, "ABC123", "Car" },
                    { 2, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Blue", "2", 4, "DEF234", "Car" },
                    { 3, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Green", "2", 4, "GHI345", "Car" },
                    { 4, new DateTime(1995, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Yellow", "2", 4, "JKL456", "Car" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
