using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage2._0.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RegNr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrOfWheels = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrOfWheels = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleTypeEntity_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VehicleTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Park_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpace_Park_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Park",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "NrOfWheels", "RegNr", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Red", "2", 4, "ABC123", 2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Blue", "2", 4, "DEF234", 0 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Green", "2", 4, "GHI345", 4 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Yellow", "2", 4, "JKL456", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Park_VehicleId",
                table: "Park",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpace_ParkId",
                table: "ParkingSpace",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MemberId",
                table: "Vehicle",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpace");

            migrationBuilder.DropTable(
                name: "Park");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "VehicleTypeEntity");
        }
    }
}
