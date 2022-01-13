using Microsoft.EntityFrameworkCore.Migrations;

namespace Mingems.Infrastructure.Migrations
{
    public partial class AddedOriginToInvestments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Origin",
                table: "Investments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Investments");
        }
    }
}
