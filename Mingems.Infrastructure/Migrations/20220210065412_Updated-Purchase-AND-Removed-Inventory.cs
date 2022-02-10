using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mingems.Infrastructure.Migrations
{
    public partial class UpdatedPurchaseANDRemovedInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageLines_Inventories_InventoryId",
                table: "ImageLines");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_ImageLines_InventoryId",
                table: "ImageLines");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "ImageLines");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CertificateCost",
                table: "Purchases",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionCost",
                table: "Purchases",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LastPriceCode",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceCode",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Purchases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RecuttingCost",
                table: "Purchases",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseId",
                table: "ImageLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageLines_PurchaseId",
                table: "ImageLines",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageLines_Purchases_PurchaseId",
                table: "ImageLines",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageLines_Purchases_PurchaseId",
                table: "ImageLines");

            migrationBuilder.DropIndex(
                name: "IX_ImageLines_PurchaseId",
                table: "ImageLines");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CertificateCost",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CommissionCost",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "LastPriceCode",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PriceCode",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RecuttingCost",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "ImageLines");

            migrationBuilder.AddColumn<string>(
                name: "InventoryId",
                table: "ImageLines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastPriceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RecordState = table.Column<int>(type: "int", nullable: false),
                    RecuttingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Investments_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Investments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageLines_InventoryId",
                table: "ImageLines",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InvestorId",
                table: "Inventories",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PurchaseId",
                table: "Inventories",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageLines_Inventories_InventoryId",
                table: "ImageLines",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
