using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Migrations
{
    public partial class UserViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsFromInventory",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CarBrand = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentCostPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentCostPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentCostPerWeek = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsFromInventory", x => x.CarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsFromInventory");
        }
    }
}
