using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2._0.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpace_Park_ParkId",
                table: "ParkingSpace");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "ParkingSpace",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ParkingSpace",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpace_Park_ParkId",
                table: "ParkingSpace",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpace_Park_ParkId",
                table: "ParkingSpace");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "ParkingSpace",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ParkingSpace",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpace_Park_ParkId",
                table: "ParkingSpace",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "Id");
        }
    }
}
