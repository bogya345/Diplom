using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClassForLecturerClasses_Lectureres_LecturerIdSLecturer",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.RenameColumn(
                name: "LecturerIdSLecturer",
                table: "ExactClassForLecturerClasses",
                newName: "LecturerIdPerson");

            migrationBuilder.RenameIndex(
                name: "IX_ExactClassForLecturerClasses_LecturerIdSLecturer",
                table: "ExactClassForLecturerClasses",
                newName: "IX_ExactClassForLecturerClasses_LecturerIdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClassForLecturerClasses_Persons_LecturerIdPerson",
                table: "ExactClassForLecturerClasses",
                column: "LecturerIdPerson",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClassForLecturerClasses_Persons_LecturerIdPerson",
                table: "ExactClassForLecturerClasses");

            migrationBuilder.RenameColumn(
                name: "LecturerIdPerson",
                table: "ExactClassForLecturerClasses",
                newName: "LecturerIdSLecturer");

            migrationBuilder.RenameIndex(
                name: "IX_ExactClassForLecturerClasses_LecturerIdPerson",
                table: "ExactClassForLecturerClasses",
                newName: "IX_ExactClassForLecturerClasses_LecturerIdSLecturer");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClassForLecturerClasses_Lectureres_LecturerIdSLecturer",
                table: "ExactClassForLecturerClasses",
                column: "LecturerIdSLecturer",
                principalTable: "Lectureres",
                principalColumn: "IdSLecturer",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
