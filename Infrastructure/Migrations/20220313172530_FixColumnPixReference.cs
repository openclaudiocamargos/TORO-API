using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixColumnPixReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentOrigin",
                table: "PixTransfers");

            migrationBuilder.AddColumn<string>(
                name: "AccountOrigin",
                table: "PixTransfers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountOrigin",
                table: "PixTransfers");

            migrationBuilder.AddColumn<string>(
                name: "DocumentOrigin",
                table: "PixTransfers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");
        }
    }
}
