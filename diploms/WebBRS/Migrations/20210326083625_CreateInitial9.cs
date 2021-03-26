using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateInitial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectForGroups_TypeStudy_TypeStudyIdTS",
                table: "SubjectForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectLecturers_TypeStudy_IdTS",
                table: "SubjectLecturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeStudy",
                table: "TypeStudy");

            migrationBuilder.RenameTable(
                name: "TypeStudy",
                newName: "TypeStudies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeStudies",
                table: "TypeStudies",
                column: "IdTS");

            migrationBuilder.CreateTable(
                name: "StudyYears",
                columns: table => new
                {
                    IdStudyYear = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyYears", x => x.IdStudyYear);
                });

            migrationBuilder.CreateTable(
                name: "TypeControls",
                columns: table => new
                {
                    IdTC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Marked = table.Column<bool>(type: "bit", nullable: false),
                    _Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Descriptpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _ShortDescr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeControls", x => x.IdTC);
                });

            migrationBuilder.CreateTable(
                name: "TypeStudyPlanRecords",
                columns: table => new
                {
                    IdTSPR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Fld9231 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeStudyPlanRecords", x => x.IdTSPR);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanRecords",
                columns: table => new
                {
                    IdStudyPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultetDepartmentGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudyYearIdStudyYear = table.Column<int>(type: "int", nullable: true),
                    SpecialtyIdSpec = table.Column<int>(type: "int", nullable: true),
                    TypeControlIdTC = table.Column<int>(type: "int", nullable: true),
                    TypeStudyPlanRecordIdTSPR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanRecords", x => x.IdStudyPlan);
                    table.ForeignKey(
                        name: "FK_StudyPlanRecords_Departments_FacultetDepartmentGUID",
                        column: x => x.FacultetDepartmentGUID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyPlanRecords_Specialties_SpecialtyIdSpec",
                        column: x => x.SpecialtyIdSpec,
                        principalTable: "Specialties",
                        principalColumn: "IdSpec",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyPlanRecords_StudyYears_StudyYearIdStudyYear",
                        column: x => x.StudyYearIdStudyYear,
                        principalTable: "StudyYears",
                        principalColumn: "IdStudyYear",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyPlanRecords_TypeControls_TypeControlIdTC",
                        column: x => x.TypeControlIdTC,
                        principalTable: "TypeControls",
                        principalColumn: "IdTC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyPlanRecords_TypeStudyPlanRecords_TypeStudyPlanRecordIdTSPR",
                        column: x => x.TypeStudyPlanRecordIdTSPR,
                        principalTable: "TypeStudyPlanRecords",
                        principalColumn: "IdTSPR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanRecords_FacultetDepartmentGUID",
                table: "StudyPlanRecords",
                column: "FacultetDepartmentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanRecords_SpecialtyIdSpec",
                table: "StudyPlanRecords",
                column: "SpecialtyIdSpec");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanRecords_StudyYearIdStudyYear",
                table: "StudyPlanRecords",
                column: "StudyYearIdStudyYear");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanRecords_TypeControlIdTC",
                table: "StudyPlanRecords",
                column: "TypeControlIdTC");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanRecords_TypeStudyPlanRecordIdTSPR",
                table: "StudyPlanRecords",
                column: "TypeStudyPlanRecordIdTSPR");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectForGroups_TypeStudies_TypeStudyIdTS",
                table: "SubjectForGroups",
                column: "TypeStudyIdTS",
                principalTable: "TypeStudies",
                principalColumn: "IdTS",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectLecturers_TypeStudies_IdTS",
                table: "SubjectLecturers",
                column: "IdTS",
                principalTable: "TypeStudies",
                principalColumn: "IdTS",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectForGroups_TypeStudies_TypeStudyIdTS",
                table: "SubjectForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectLecturers_TypeStudies_IdTS",
                table: "SubjectLecturers");

            migrationBuilder.DropTable(
                name: "StudyPlanRecords");

            migrationBuilder.DropTable(
                name: "StudyYears");

            migrationBuilder.DropTable(
                name: "TypeControls");

            migrationBuilder.DropTable(
                name: "TypeStudyPlanRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeStudies",
                table: "TypeStudies");

            migrationBuilder.RenameTable(
                name: "TypeStudies",
                newName: "TypeStudy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeStudy",
                table: "TypeStudy",
                column: "IdTS");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectForGroups_TypeStudy_TypeStudyIdTS",
                table: "SubjectForGroups",
                column: "TypeStudyIdTS",
                principalTable: "TypeStudy",
                principalColumn: "IdTS",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectLecturers_TypeStudy_IdTS",
                table: "SubjectLecturers",
                column: "IdTS",
                principalTable: "TypeStudy",
                principalColumn: "IdTS",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
