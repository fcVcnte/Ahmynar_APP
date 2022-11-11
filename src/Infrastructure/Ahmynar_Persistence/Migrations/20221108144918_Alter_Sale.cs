using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahmynar_Persistence.Migrations
{
    public partial class Alter_Sale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeSale",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeSale",
                table: "Sales");
        }
    }
}
