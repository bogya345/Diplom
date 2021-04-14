using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditoryDepartmentID",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_1c_audit",
                table: "ExactClasses",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_1c_person",
                table: "ExactClasses",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_AuditoryDepartmentID",
                table: "ExactClasses",
                column: "AuditoryDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_Departments_AuditoryDepartmentID",
                table: "ExactClasses",
                column: "AuditoryDepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_Departments_AuditoryDepartmentID",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_AuditoryDepartmentID",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "AuditoryDepartmentID",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "ID_1c_audit",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "ID_1c_person",
                table: "ExactClasses");
        }
    }
}
