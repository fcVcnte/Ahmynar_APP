using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ahmynar_Persistence.Migrations
{
    public partial class Create_Service_AND_ServiceOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalDiscounts",
                table: "Budgets",
                newName: "TotalServices");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Budgets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalProducts",
                table: "Budgets",
                type: "real",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BudgetProduct",
                columns: table => new
                {
                    BudgetsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetProduct", x => new { x.BudgetsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_BudgetProduct_Budgets_BudgetsId",
                        column: x => x.BudgetsId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalDiscounts = table.Column<float>(type: "real", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrders_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalePrice = table.Column<float>(type: "real", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetService",
                columns: table => new
                {
                    BudgetsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetService", x => new { x.BudgetsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_BudgetService_Budgets_BudgetsId",
                        column: x => x.BudgetsId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetProduct_ProductsId",
                table: "BudgetProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetService_ServicesId",
                table: "BudgetService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_BudgetId",
                table: "ServiceOrders",
                column: "BudgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetProduct");

            migrationBuilder.DropTable(
                name: "BudgetService");

            migrationBuilder.DropTable(
                name: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TotalProducts",
                table: "Budgets");

            migrationBuilder.RenameColumn(
                name: "TotalServices",
                table: "Budgets",
                newName: "TotalDiscounts");
        }
    }
}
