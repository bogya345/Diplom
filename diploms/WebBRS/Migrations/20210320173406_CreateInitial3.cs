using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateInitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ClassNumber",
                table: "ExactClassForLecturerClasses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ClassNumber",
                table: "ExactClasses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "ExactClasses");
        }
    }
}
