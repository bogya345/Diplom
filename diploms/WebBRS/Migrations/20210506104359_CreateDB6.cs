using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_Persons_PersonLecturerIdPerson",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_SubjectForGroups_IdSFG",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_SubjectLecturers_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_IdSFG",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "IdSFG",
                table: "ExactClasses");

            migrationBuilder.RenameColumn(
                name: "SubjectLecturerIdSubject",
                table: "ExactClasses",
                newName: "TypeTimeTableidTTT");

            migrationBuilder.RenameColumn(
                name: "SubjectLecturerIdLecturer",
                table: "ExactClasses",
                newName: "DraftTimeTableIdDFTT");

            migrationBuilder.AlterColumn<int>(
                name: "ID_reff",
                table: "SubjectForGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DraftTimeTableIdDFTT",
                table: "SubjectForGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonLecturerIdPerson",
                table: "ExactClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_reff",
                table: "ExactClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DraftTimeTable",
                columns: table => new
                {
                    IdDFTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdStudyYear = table.Column<int>(type: "int", nullable: false),
                    StudyYearIdStudyYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftTimeTable", x => x.IdDFTT);
                    table.ForeignKey(
                        name: "FK_DraftTimeTable_StudyYears_StudyYearIdStudyYear",
                        column: x => x.StudyYearIdStudyYear,
                        principalTable: "StudyYears",
                        principalColumn: "IdStudyYear",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeTimeTable",
                columns: table => new
                {
                    idTTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTimeTable", x => x.idTTT);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_DraftTimeTableIdDFTT",
                table: "SubjectForGroups",
                column: "DraftTimeTableIdDFTT");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_DraftTimeTableIdDFTT",
                table: "ExactClasses",
                column: "DraftTimeTableIdDFTT");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_TypeTimeTableidTTT",
                table: "ExactClasses",
                column: "TypeTimeTableidTTT");

            migrationBuilder.CreateIndex(
                name: "IX_DraftTimeTable_StudyYearIdStudyYear",
                table: "DraftTimeTable",
                column: "StudyYearIdStudyYear");

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_DraftTimeTable_DraftTimeTableIdDFTT",
                table: "ExactClasses",
                column: "DraftTimeTableIdDFTT",
                principalTable: "DraftTimeTable",
                principalColumn: "IdDFTT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_Persons_PersonLecturerIdPerson",
                table: "ExactClasses",
                column: "PersonLecturerIdPerson",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_TypeTimeTable_TypeTimeTableidTTT",
                table: "ExactClasses",
                column: "TypeTimeTableidTTT",
                principalTable: "TypeTimeTable",
                principalColumn: "idTTT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectForGroups_DraftTimeTable_DraftTimeTableIdDFTT",
                table: "SubjectForGroups",
                column: "DraftTimeTableIdDFTT",
                principalTable: "DraftTimeTable",
                principalColumn: "IdDFTT",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_DraftTimeTable_DraftTimeTableIdDFTT",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_Persons_PersonLecturerIdPerson",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_TypeTimeTable_TypeTimeTableidTTT",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectForGroups_DraftTimeTable_DraftTimeTableIdDFTT",
                table: "SubjectForGroups");

            migrationBuilder.DropTable(
                name: "DraftTimeTable");

            migrationBuilder.DropTable(
                name: "TypeTimeTable");

            migrationBuilder.DropIndex(
                name: "IX_SubjectForGroups_DraftTimeTableIdDFTT",
                table: "SubjectForGroups");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_DraftTimeTableIdDFTT",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_TypeTimeTableidTTT",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "DraftTimeTableIdDFTT",
                table: "SubjectForGroups");

            migrationBuilder.RenameColumn(
                name: "TypeTimeTableidTTT",
                table: "ExactClasses",
                newName: "SubjectLecturerIdSubject");

            migrationBuilder.RenameColumn(
                name: "DraftTimeTableIdDFTT",
                table: "ExactClasses",
                newName: "SubjectLecturerIdLecturer");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ID_reff",
                table: "SubjectForGroups",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonLecturerIdPerson",
                table: "ExactClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ID_reff",
                table: "ExactClasses",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte>(
                name: "ClassNumber",
                table: "ExactClasses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "IdSFG",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_IdSFG",
                table: "ExactClasses",
                column: "IdSFG");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses",
                columns: new[] { "SubjectLecturerIdLecturer", "SubjectLecturerIdSubject" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_Persons_PersonLecturerIdPerson",
                table: "ExactClasses",
                column: "PersonLecturerIdPerson",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_SubjectForGroups_IdSFG",
                table: "ExactClasses",
                column: "IdSFG",
                principalTable: "SubjectForGroups",
                principalColumn: "IdSFG",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_SubjectLecturers_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses",
                columns: new[] { "SubjectLecturerIdLecturer", "SubjectLecturerIdSubject" },
                principalTable: "SubjectLecturers",
                principalColumns: new[] { "IdLecturer", "IdSubject" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
