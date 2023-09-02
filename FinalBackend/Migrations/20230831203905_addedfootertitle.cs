using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBackend.Migrations
{
    public partial class addedfootertitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterText",
                table: "settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterTitle",
                table: "settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterText",
                table: "settings");

            migrationBuilder.DropColumn(
                name: "FooterTitle",
                table: "settings");
        }
    }
}
