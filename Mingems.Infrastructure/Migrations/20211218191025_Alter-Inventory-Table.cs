using Microsoft.EntityFrameworkCore.Migrations;

namespace Mingems.Infrastructure.Migrations
{
    public partial class AlterInventoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Purchases_PurchaseId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_PurchaseId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "InvenstorId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestorId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InvestorId",
                table: "Inventories",
                column: "InvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Investments_InvestorId",
                table: "Inventories",
                column: "InvestorId",
                principalTable: "Investments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Investments_InvestorId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InvestorId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InvenstorId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseId",
                table: "Inventories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PurchaseId",
                table: "Inventories",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Purchases_PurchaseId",
                table: "Inventories",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
