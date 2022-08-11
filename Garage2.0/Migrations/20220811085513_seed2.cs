using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2._0.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingNr",
                table: "ParkingSpace",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkingSpace",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkingNr",
                value: 1);

            migrationBuilder.InsertData(
                table: "ParkingSpace",
                columns: new[] { "Id", "ParkId", "ParkingNr" },
                values: new object[] { 2, null, 2 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "Color", "MemberId", "Model", "NrOfWheels", "RegNr", "VehicleTypeEntityId" },
                values: new object[,]
                {
                    { 2, "Mercedes", "Black", 1, "X100", 4, "BBB222", 1 },
                    { 3, "Ferrari", "White", 1, "E-Type", 4, "CCC333", 1 },
                    { 4, "Volvo", "Blue", 2, "V20", 4, "DDD444", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpace",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ParkingNr",
                table: "ParkingSpace");
        }
    }
}
