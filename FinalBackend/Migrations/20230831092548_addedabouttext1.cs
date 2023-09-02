using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBackend.Migrations
{
    public partial class addedabouttext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutText1",
                table: "settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutText2",
                table: "settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutText1",
                table: "settings");

            migrationBuilder.DropColumn(
                name: "AboutText2",
                table: "settings");
        }
    }
}
