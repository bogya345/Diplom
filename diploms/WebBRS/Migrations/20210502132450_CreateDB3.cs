using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditoryaDepartmentID",
                table: "ExactClassForLecturerClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExactClassForLecturerClasses_AuditoryaDepartmentID",
                table: "ExactClassForLecturerClasses",
                column: "AuditoryaDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClassForLecturerClasses_Departments_AuditoryaDepartmentID",
                table: "ExactClassForLecturerClasses",
                column: "AuditoryaDepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClassForLecturerClasses_Departments_AuditoryaDepartmentID",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClassForLecturerClasses_AuditoryaDepartmentID",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.DropColumn(
                name: "AuditoryaDepartmentID",
                table: "ExactClassForLecturerClasses");
        }
    }
}
