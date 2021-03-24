using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateClass",
                table: "ExactClasses",
                newName: "DateClassStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateClassEnd",
                table: "ExactClasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonLecturerGuidPerson",
                table: "ExactClasses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_PersonLecturerGuidPerson",
                table: "ExactClasses",
                column: "PersonLecturerGuidPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_Persons_PersonLecturerGuidPerson",
                table: "ExactClasses",
                column: "PersonLecturerGuidPerson",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "GuidPerson",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_Persons_PersonLecturerGuidPerson",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_PersonLecturerGuidPerson",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "DateClassEnd",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "PersonLecturerGuidPerson",
                table: "ExactClasses");

            migrationBuilder.RenameColumn(
                name: "DateClassStart",
                table: "ExactClasses",
                newName: "DateClass");
        }
    }
}
