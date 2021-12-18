using Microsoft.EntityFrameworkCore.Migrations;

namespace Mingems.Infrastructure.Migrations
{
    public partial class AddedPurchaseIdToInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseId",
                table: "Inventories",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
