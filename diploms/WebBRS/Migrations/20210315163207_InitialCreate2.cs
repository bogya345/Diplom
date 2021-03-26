using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSL",
                table: "SubjectLecturers");

            migrationBuilder.AddColumn<int>(
                name: "ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerIdSLecturer",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectLecturerIdLecturer",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectLecturerIdSubject",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExactClassForLecturerClasses",
                columns: table => new
                {
                    IdEXCFLC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerIdSLecturer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExactClassForLecturerClasses", x => x.IdEXCFLC);
                    table.ForeignKey(
                        name: "FK_ExactClassForLecturerClasses_Lectureres_LecturerIdSLecturer",
                        column: x => x.LecturerIdSLecturer,
                        principalTable: "Lectureres",
                        principalColumn: "IdSLecturer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses",
                column: "ExactClassForLecturerClassIdEXCFLC");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_LecturerIdSLecturer",
                table: "ExactClasses",
                column: "LecturerIdSLecturer");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses",
                columns: new[] { "SubjectLecturerIdLecturer", "SubjectLecturerIdSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_ExactClassForLecturerClasses_LecturerIdSLecturer",
                table: "ExactClassForLecturerClasses",
                column: "LecturerIdSLecturer");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_ExactClassForLecturerClasses_ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses",
                column: "ExactClassForLecturerClassIdEXCFLC",
                principalTable: "ExactClassForLecturerClasses",
                principalColumn: "IdEXCFLC",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_Lectureres_LecturerIdSLecturer",
                table: "ExactClasses",
                column: "LecturerIdSLecturer",
                principalTable: "Lectureres",
                principalColumn: "IdSLecturer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_SubjectLecturers_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses",
                columns: new[] { "SubjectLecturerIdLecturer", "SubjectLecturerIdSubject" },
                principalTable: "SubjectLecturers",
                principalColumns: new[] { "IdLecturer", "IdSubject" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_ExactClassForLecturerClasses_ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_Lectureres_LecturerIdSLecturer",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_SubjectLecturers_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses");

            migrationBuilder.DropTable(
                name: "ExactClassForLecturerClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_LecturerIdSLecturer",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "LecturerIdSLecturer",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "SubjectLecturerIdLecturer",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "SubjectLecturerIdSubject",
                table: "ExactClasses");

            migrationBuilder.AddColumn<int>(
                name: "IdSL",
                table: "SubjectLecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
