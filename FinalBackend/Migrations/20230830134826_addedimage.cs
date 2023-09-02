using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBackend.Migrations
{
    public partial class addedimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "settings");

            migrationBuilder.AlterColumn<string>(
                name: "AboutImage",
                table: "settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "settings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "settings");

            migrationBuilder.AlterColumn<string>(
                name: "AboutImage",
                table: "settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
