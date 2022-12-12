using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahmynar_Persistence.Migrations
{
    public partial class Alter_Sale_ServiceOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDiscounts",
                table: "ServiceOrders");

            migrationBuilder.AddColumn<float>(
                name: "TotalDiscounts",
                table: "Sales",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDiscounts",
                table: "Sales");

            migrationBuilder.AddColumn<float>(
                name: "TotalDiscounts",
                table: "ServiceOrders",
                type: "real",
                nullable: true);
        }
    }
}
