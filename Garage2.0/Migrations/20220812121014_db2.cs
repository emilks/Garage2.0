using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2._0.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "Type" },
                values: new object[] { 1, new DateTime(2022, 8, 12, 14, 10, 14, 669, DateTimeKind.Local).AddTicks(8225), "Volvo", "Red", "V20", 4, "AAA111", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
