using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "ExactClassForLecturerClasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "ExactClassForLecturerClasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.AddColumn<byte>(
                name: "ClassNumber",
                table: "ExactClassForLecturerClasses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
