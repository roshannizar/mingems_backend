using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mingems.Infrastructure.Migrations
{
    public partial class AddedPrivateCode2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrivateCodes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PriceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateCodes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateCodes");
        }
    }
}
