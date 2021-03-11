using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTypes",
                columns: table => new
                {
                    DepartTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullDepartTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDepartTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypes", x => x.DepartTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    GuidPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatronicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.GuidPerson);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    IdSpec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSpec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortNameSpec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.IdSpec);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeSubject = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IdSubject);
                });

            migrationBuilder.CreateTable(
                name: "TypeStudy",
                columns: table => new
                {
                    IdTS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeStudyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortTypeStudyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeStudy", x => x.IdTS);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    IdWT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortWorkTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.IdWT);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    IdDepart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortNameDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadDepartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HeadDepartIdDepart = table.Column<int>(type: "int", nullable: true),
                    DepartmentTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.IdDepart);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_HeadDepartIdDepart",
                        column: x => x.HeadDepartIdDepart,
                        principalTable: "Departments",
                        principalColumn: "IdDepart",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_DepartmentTypes_DepartmentTypeID",
                        column: x => x.DepartmentTypeID,
                        principalTable: "DepartmentTypes",
                        principalColumn: "DepartTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lectureres",
                columns: table => new
                {
                    IdSLecturer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonGuidPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectureres", x => x.IdSLecturer);
                    table.ForeignKey(
                        name: "FK_Lectureres_Persons_PersonGuidPerson",
                        column: x => x.PersonGuidPerson,
                        principalTable: "Persons",
                        principalColumn: "GuidPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ZachNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_Persons_GuidPerson",
                        column: x => x.GuidPerson,
                        principalTable: "Persons",
                        principalColumn: "GuidPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSpec = table.Column<int>(type: "int", nullable: true),
                    SpecialtyIdSpec = table.Column<int>(type: "int", nullable: true),
                    IdDepart = table.Column<int>(type: "int", nullable: true),
                    DepartmentGroupIdDepart = table.Column<int>(type: "int", nullable: true),
                    IdGroupPrev = table.Column<int>(type: "int", nullable: true),
                    GroupPrevIdGroup = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroup);
                    table.ForeignKey(
                        name: "FK_Groups_Departments_DepartmentGroupIdDepart",
                        column: x => x.DepartmentGroupIdDepart,
                        principalTable: "Departments",
                        principalColumn: "IdDepart",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_GroupPrevIdGroup",
                        column: x => x.GroupPrevIdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Specialties_SpecialtyIdSpec",
                        column: x => x.SpecialtyIdSpec,
                        principalTable: "Specialties",
                        principalColumn: "IdSpec",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectLecturers",
                columns: table => new
                {
                    IdLecturer = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    IdSL = table.Column<int>(type: "int", nullable: false),
                    IdTS = table.Column<int>(type: "int", nullable: false),
                    SLDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectLecturers", x => new { x.IdLecturer, x.IdSubject });
                    table.ForeignKey(
                        name: "FK_SubjectLecturers_Lectureres_IdLecturer",
                        column: x => x.IdLecturer,
                        principalTable: "Lectureres",
                        principalColumn: "IdSLecturer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectLecturers_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectLecturers_TypeStudy_IdTS",
                        column: x => x.IdTS,
                        principalTable: "TypeStudy",
                        principalColumn: "IdTS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroupHistories",
                columns: table => new
                {
                    IdSGH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSGHStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSGHFinished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: true),
                    StudentIdStudent = table.Column<int>(type: "int", nullable: true),
                    IdGroup = table.Column<int>(type: "int", nullable: true),
                    GroupIdGroup = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupHistories", x => x.IdSGH);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_Groups_GroupIdGroup",
                        column: x => x.GroupIdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_Students_StudentIdStudent",
                        column: x => x.StudentIdStudent,
                        principalTable: "Students",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectForGroups",
                columns: table => new
                {
                    IdSFG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSubject = table.Column<int>(type: "int", nullable: true),
                    IdGroup = table.Column<int>(type: "int", nullable: true),
                    IdSLecturer = table.Column<int>(type: "int", nullable: true),
                    LecturerIdLecturer = table.Column<int>(type: "int", nullable: true),
                    LecturerIdSubject = table.Column<int>(type: "int", nullable: true),
                    IdTS = table.Column<int>(type: "int", nullable: true),
                    TypeStudyIdTS = table.Column<int>(type: "int", nullable: true),
                    SFGDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LecturerIdSLecturer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectForGroups", x => x.IdSFG);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Lectureres_LecturerIdSLecturer",
                        column: x => x.LecturerIdSLecturer,
                        principalTable: "Lectureres",
                        principalColumn: "IdSLecturer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_SubjectLecturers_LecturerIdLecturer_LecturerIdSubject",
                        columns: x => new { x.LecturerIdLecturer, x.LecturerIdSubject },
                        principalTable: "SubjectLecturers",
                        principalColumns: new[] { "IdLecturer", "IdSubject" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_TypeStudy_TypeStudyIdTS",
                        column: x => x.TypeStudyIdTS,
                        principalTable: "TypeStudy",
                        principalColumn: "IdTS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExactClasses",
                columns: table => new
                {
                    IdClass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSFG = table.Column<int>(type: "int", nullable: true),
                    SubjectForGroupIdSFG = table.Column<int>(type: "int", nullable: true),
                    DateClass = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExactClasses", x => x.IdClass);
                    table.ForeignKey(
                        name: "FK_ExactClasses_SubjectForGroups_SubjectForGroupIdSFG",
                        column: x => x.SubjectForGroupIdSFG,
                        principalTable: "SubjectForGroups",
                        principalColumn: "IdSFG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    IdAtt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSGH = table.Column<int>(type: "int", nullable: true),
                    SGHIdSGH = table.Column<int>(type: "int", nullable: true),
                    IdClass = table.Column<int>(type: "int", nullable: true),
                    ExactClassIdClass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.IdAtt);
                    table.ForeignKey(
                        name: "FK_Attendances_ExactClasses_ExactClassIdClass",
                        column: x => x.ExactClassIdClass,
                        principalTable: "ExactClasses",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_StudentsGroupHistories_SGHIdSGH",
                        column: x => x.SGHIdSGH,
                        principalTable: "StudentsGroupHistories",
                        principalColumn: "IdSGH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassWorks",
                columns: table => new
                {
                    IdClassWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClass = table.Column<int>(type: "int", nullable: true),
                    ExactClassIdClass = table.Column<int>(type: "int", nullable: true),
                    TextWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePathWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBall = table.Column<double>(type: "float", nullable: false),
                    IdWT = table.Column<int>(type: "int", nullable: true),
                    WorkTypeIdWT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWorks", x => x.IdClassWork);
                    table.ForeignKey(
                        name: "FK_ClassWorks_ExactClasses_ExactClassIdClass",
                        column: x => x.ExactClassIdClass,
                        principalTable: "ExactClasses",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassWorks_WorkTypes_WorkTypeIdWT",
                        column: x => x.WorkTypeIdWT,
                        principalTable: "WorkTypes",
                        principalColumn: "IdWT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoClassWorkAttends",
                columns: table => new
                {
                    IdDCWA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClassWork = table.Column<int>(type: "int", nullable: true),
                    ClassWorkIdClassWork = table.Column<int>(type: "int", nullable: true),
                    IdAtt = table.Column<int>(type: "int", nullable: true),
                    AttendanceIdAtt = table.Column<int>(type: "int", nullable: true),
                    DateTimePass = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextDoClassWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ball = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoClassWorkAttends", x => x.IdDCWA);
                    table.ForeignKey(
                        name: "FK_DoClassWorkAttends_Attendances_AttendanceIdAtt",
                        column: x => x.AttendanceIdAtt,
                        principalTable: "Attendances",
                        principalColumn: "IdAtt",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoClassWorkAttends_ClassWorks_ClassWorkIdClassWork",
                        column: x => x.ClassWorkIdClassWork,
                        principalTable: "ClassWorks",
                        principalColumn: "IdClassWork",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ExactClassIdClass",
                table: "Attendances",
                column: "ExactClassIdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_SGHIdSGH",
                table: "Attendances",
                column: "SGHIdSGH");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWorks_ExactClassIdClass",
                table: "ClassWorks",
                column: "ExactClassIdClass");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWorks_WorkTypeIdWT",
                table: "ClassWorks",
                column: "WorkTypeIdWT");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentTypeID",
                table: "Departments",
                column: "DepartmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadDepartIdDepart",
                table: "Departments",
                column: "HeadDepartIdDepart");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_AttendanceIdAtt",
                table: "DoClassWorkAttends",
                column: "AttendanceIdAtt");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_ClassWorkIdClassWork",
                table: "DoClassWorkAttends",
                column: "ClassWorkIdClassWork");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_SubjectForGroupIdSFG",
                table: "ExactClasses",
                column: "SubjectForGroupIdSFG");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentGroupIdDepart",
                table: "Groups",
                column: "DepartmentGroupIdDepart");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupPrevIdGroup",
                table: "Groups",
                column: "GroupPrevIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyIdSpec",
                table: "Groups",
                column: "SpecialtyIdSpec");

            migrationBuilder.CreateIndex(
                name: "IX_Lectureres_PersonGuidPerson",
                table: "Lectureres",
                column: "PersonGuidPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GuidPerson",
                table: "Students",
                column: "GuidPerson");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_GroupIdGroup",
                table: "StudentsGroupHistories",
                column: "GroupIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_StudentIdStudent",
                table: "StudentsGroupHistories",
                column: "StudentIdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_IdGroup",
                table: "SubjectForGroups",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_IdSubject",
                table: "SubjectForGroups",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_LecturerIdLecturer_LecturerIdSubject",
                table: "SubjectForGroups",
                columns: new[] { "LecturerIdLecturer", "LecturerIdSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_LecturerIdSLecturer",
                table: "SubjectForGroups",
                column: "LecturerIdSLecturer");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_TypeStudyIdTS",
                table: "SubjectForGroups",
                column: "TypeStudyIdTS");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectLecturers_IdSubject",
                table: "SubjectLecturers",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectLecturers_IdTS",
                table: "SubjectLecturers",
                column: "IdTS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoClassWorkAttends");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "ClassWorks");

            migrationBuilder.DropTable(
                name: "StudentsGroupHistories");

            migrationBuilder.DropTable(
                name: "ExactClasses");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectForGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "SubjectLecturers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Lectureres");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TypeStudy");

            migrationBuilder.DropTable(
                name: "DepartmentTypes");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
