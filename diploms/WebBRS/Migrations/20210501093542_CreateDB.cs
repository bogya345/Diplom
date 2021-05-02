using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ConditionOfPersons",
                columns: table => new
                {
                    IdConditionOfPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionOfPersons", x => x.IdConditionOfPerson);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IdCourse);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentTypes",
                columns: table => new
                {
                    DepartTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FullDepartTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDepartTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypes", x => x.DepartTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "dbo",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    _Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatronicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhotoFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "SemestrBases",
                columns: table => new
                {
                    IdSemestr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NameSemestr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemestrBases", x => x.IdSemestr);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    IdSpec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ID_1c_int = table.Column<int>(type: "int", nullable: false),
                    NameSpec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortNameSpec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.IdSpec);
                });

            migrationBuilder.CreateTable(
                name: "StudyYears",
                columns: table => new
                {
                    IdStudyYear = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                name: "Subjects",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NameSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeSubject = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IdSubject);
                });

            migrationBuilder.CreateTable(
                name: "TypeAttedances",
                columns: table => new
                {
                    IdTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TAShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAttedances", x => x.IdTA);
                });

            migrationBuilder.CreateTable(
                name: "TypeControls",
                columns: table => new
                {
                    IdTC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                name: "TypeStudies",
                columns: table => new
                {
                    IdTS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TypeStudyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortTypeStudyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeStudies", x => x.IdTS);
                });

            migrationBuilder.CreateTable(
                name: "TypeStudyPlanRecords",
                columns: table => new
                {
                    IdTSPR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    _Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _Fld9231 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeStudyPlanRecords", x => x.IdTSPR);
                });

            migrationBuilder.CreateTable(
                name: "WorkPersonStatuses",
                columns: table => new
                {
                    IdWPS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    WorkpersonStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkpersonStatusNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPersonStatuses", x => x.IdWPS);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    IdWT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FullNameDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortNameDepart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadDepartId = table.Column<int>(type: "int", nullable: true),
                    DepartmentTypeDepartTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_HeadDepartId",
                        column: x => x.HeadDepartId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_DepartmentTypes_DepartmentTypeDepartTypeID",
                        column: x => x.DepartmentTypeDepartTypeID,
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
                    PersonIdPerson = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectureres", x => x.IdSLecturer);
                    table.ForeignKey(
                        name: "FK_Lectureres_Persons_PersonIdPerson",
                        column: x => x.PersonIdPerson,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Person_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    ZachNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_Persons_IdPerson",
                        column: x => x.IdPerson,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonIdPerson = table.Column<int>(type: "int", nullable: true),
                    Roleid_role = table.Column<int>(type: "int", nullable: true),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonIdPerson",
                        column: x => x.PersonIdPerson,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Roleid_role",
                        column: x => x.Roleid_role,
                        principalTable: "Roles",
                        principalColumn: "id_role",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtyIdSpec = table.Column<int>(type: "int", nullable: true),
                    DepartmentGroupDepartmentID = table.Column<int>(type: "int", nullable: true),
                    GroupPrevIdGroup = table.Column<int>(type: "int", nullable: true),
                    GroupPrev_ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroup);
                    table.ForeignKey(
                        name: "FK_Groups_Departments_DepartmentGroupDepartmentID",
                        column: x => x.DepartmentGroupDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
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
                name: "StudyPlanRecords",
                columns: table => new
                {
                    IdStudyPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FacultetDepartmentID = table.Column<int>(type: "int", nullable: true),
                    StudyYearIdStudyYear = table.Column<int>(type: "int", nullable: true),
                    SpecialtyIdSpec = table.Column<int>(type: "int", nullable: true),
                    TypeControlIdTC = table.Column<int>(type: "int", nullable: true),
                    TypeStudyPlanRecordIdTSPR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanRecords", x => x.IdStudyPlan);
                    table.ForeignKey(
                        name: "FK_StudyPlanRecords_Departments_FacultetDepartmentID",
                        column: x => x.FacultetDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
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

            migrationBuilder.CreateTable(
                name: "ExactClassForLecturerClasses",
                columns: table => new
                {
                    IdEXCFLC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerIdSLecturer = table.Column<int>(type: "int", nullable: true),
                    ClassNumber = table.Column<byte>(type: "tinyint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SubjectLecturers",
                columns: table => new
                {
                    IdLecturer = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_SubjectLecturers_TypeStudies_IdTS",
                        column: x => x.IdTS,
                        principalTable: "TypeStudies",
                        principalColumn: "IdTS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curators",
                columns: table => new
                {
                    CuratorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonIdPerson = table.Column<int>(type: "int", nullable: true),
                    GroupIdGroup = table.Column<int>(type: "int", nullable: true),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actual = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curators", x => x.CuratorID);
                    table.ForeignKey(
                        name: "FK_Curators_Groups_GroupIdGroup",
                        column: x => x.GroupIdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curators_Persons_PersonIdPerson",
                        column: x => x.PersonIdPerson,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroupHistories",
                columns: table => new
                {
                    IdSGH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_1c = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateSGHStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSGHFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudyYearIdStudyYear = table.Column<int>(type: "int", nullable: true),
                    ID_1c_Course = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ID_1c_Person = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ID_1c_Group = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ID_1c_CounditionOfPerson = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ConditionOfPersonIdConditionOfPerson = table.Column<int>(type: "int", nullable: true),
                    GroupIdGroup = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    CourseIdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupHistories", x => x.IdSGH);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_ConditionOfPersons_ConditionOfPersonIdConditionOfPerson",
                        column: x => x.ConditionOfPersonIdConditionOfPerson,
                        principalTable: "ConditionOfPersons",
                        principalColumn: "IdConditionOfPerson",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_Courses_CourseIdCourse",
                        column: x => x.CourseIdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_Groups_GroupIdGroup",
                        column: x => x.GroupIdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_Students_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Students",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupHistories_StudyYears_StudyYearIdStudyYear",
                        column: x => x.StudyYearIdStudyYear,
                        principalTable: "StudyYears",
                        principalColumn: "IdStudyYear",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectForGroups",
                columns: table => new
                {
                    IdSFG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStudyPlan = table.Column<int>(type: "int", nullable: false),
                    IdGroup = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    LecturerIdLecturer = table.Column<int>(type: "int", nullable: true),
                    LecturerIdSubject = table.Column<int>(type: "int", nullable: true),
                    TypeStudyIdTS = table.Column<int>(type: "int", nullable: true),
                    SFGDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LecturerIdSLecturer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectForGroups", x => x.IdSFG);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Lectureres_LecturerIdSLecturer",
                        column: x => x.LecturerIdSLecturer,
                        principalTable: "Lectureres",
                        principalColumn: "IdSLecturer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_Persons_IdPerson",
                        column: x => x.IdPerson,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_StudyPlanRecords_IdStudyPlan",
                        column: x => x.IdStudyPlan,
                        principalTable: "StudyPlanRecords",
                        principalColumn: "IdStudyPlan",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectForGroups_TypeStudies_TypeStudyIdTS",
                        column: x => x.TypeStudyIdTS,
                        principalTable: "TypeStudies",
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
                    DateClassStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClassEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    ExactClassForLecturerClassIdEXCFLC = table.Column<int>(type: "int", nullable: true),
                    SubjectLecturerIdLecturer = table.Column<int>(type: "int", nullable: true),
                    SubjectLecturerIdSubject = table.Column<int>(type: "int", nullable: true),
                    PersonLecturerIdPerson = table.Column<int>(type: "int", nullable: true),
                    ID_1c_person = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ID_1c_audit = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AuditoryDepartmentID = table.Column<int>(type: "int", nullable: true),
                    LecturerIdSLecturer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExactClasses", x => x.IdClass);
                    table.ForeignKey(
                        name: "FK_ExactClasses_Departments_AuditoryDepartmentID",
                        column: x => x.AuditoryDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExactClasses_ExactClassForLecturerClasses_ExactClassForLecturerClassIdEXCFLC",
                        column: x => x.ExactClassForLecturerClassIdEXCFLC,
                        principalTable: "ExactClassForLecturerClasses",
                        principalColumn: "IdEXCFLC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExactClasses_Lectureres_LecturerIdSLecturer",
                        column: x => x.LecturerIdSLecturer,
                        principalTable: "Lectureres",
                        principalColumn: "IdSLecturer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExactClasses_Persons_PersonLecturerIdPerson",
                        column: x => x.PersonLecturerIdPerson,
                        principalSchema: "dbo",
                        principalTable: "Persons",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExactClasses_SubjectForGroups_IdSFG",
                        column: x => x.IdSFG,
                        principalTable: "SubjectForGroups",
                        principalColumn: "IdSFG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExactClasses_SubjectLecturers_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                        columns: x => new { x.SubjectLecturerIdLecturer, x.SubjectLecturerIdSubject },
                        principalTable: "SubjectLecturers",
                        principalColumns: new[] { "IdLecturer", "IdSubject" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassWorks",
                columns: table => new
                {
                    IdClassWork = table.Column<int>(type: "int", nullable: false),
                    TextWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePathWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBall = table.Column<double>(type: "float", nullable: false),
                    DateGiven = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClasss = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWorks", x => x.IdClassWork);
                    table.ForeignKey(
                        name: "FK_ClassWorks_ExactClasses_IdClassWork",
                        column: x => x.IdClassWork,
                        principalTable: "ExactClasses",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassWorks_WorkTypes_IdClassWork",
                        column: x => x.IdClassWork,
                        principalTable: "WorkTypes",
                        principalColumn: "IdWT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    IdAtt = table.Column<int>(type: "int", nullable: false),
                    ExactClassIdClass = table.Column<int>(type: "int", nullable: true),
                    TypeAttedanceIdTA = table.Column<int>(type: "int", nullable: true),
                    ClassWorkIdClassWork = table.Column<int>(type: "int", nullable: true),
                    DateTimePass = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextDoClassWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ball = table.Column<double>(type: "float", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    DatePass = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkPersonStatusIdWPS = table.Column<int>(type: "int", nullable: true),
                    ExactClassForLecturerClassIdEXCFLC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.IdAtt);
                    table.ForeignKey(
                        name: "FK_Attendances_ClassWorks_ClassWorkIdClassWork",
                        column: x => x.ClassWorkIdClassWork,
                        principalTable: "ClassWorks",
                        principalColumn: "IdClassWork",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_ExactClasses_ExactClassIdClass",
                        column: x => x.ExactClassIdClass,
                        principalTable: "ExactClasses",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_ExactClassForLecturerClasses_ExactClassForLecturerClassIdEXCFLC",
                        column: x => x.ExactClassForLecturerClassIdEXCFLC,
                        principalTable: "ExactClassForLecturerClasses",
                        principalColumn: "IdEXCFLC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_StudentsGroupHistories_IdAtt",
                        column: x => x.IdAtt,
                        principalTable: "StudentsGroupHistories",
                        principalColumn: "IdSGH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                        column: x => x.TypeAttedanceIdTA,
                        principalTable: "TypeAttedances",
                        principalColumn: "IdTA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_WorkPersonStatuses_WorkPersonStatusIdWPS",
                        column: x => x.WorkPersonStatusIdWPS,
                        principalTable: "WorkPersonStatuses",
                        principalColumn: "IdWPS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoClassWorkAttends",
                columns: table => new
                {
                    IdDCWA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClassWork = table.Column<int>(type: "int", nullable: true),
                    DateTimePass = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextDoClassWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ball = table.Column<double>(type: "float", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    DatePass = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkPersonStatusIdWPS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoClassWorkAttends", x => x.IdDCWA);
                    table.ForeignKey(
                        name: "FK_DoClassWorkAttends_ClassWorks_IdClassWork",
                        column: x => x.IdClassWork,
                        principalTable: "ClassWorks",
                        principalColumn: "IdClassWork",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoClassWorkAttends_WorkPersonStatuses_WorkPersonStatusIdWPS",
                        column: x => x.WorkPersonStatusIdWPS,
                        principalTable: "WorkPersonStatuses",
                        principalColumn: "IdWPS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClassWorkIdClassWork",
                table: "Attendances",
                column: "ClassWorkIdClassWork");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ExactClassForLecturerClassIdEXCFLC",
                table: "Attendances",
                column: "ExactClassForLecturerClassIdEXCFLC");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ExactClassIdClass",
                table: "Attendances",
                column: "ExactClassIdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TypeAttedanceIdTA",
                table: "Attendances",
                column: "TypeAttedanceIdTA");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_WorkPersonStatusIdWPS",
                table: "Attendances",
                column: "WorkPersonStatusIdWPS");

            migrationBuilder.CreateIndex(
                name: "IX_Curators_GroupIdGroup",
                table: "Curators",
                column: "GroupIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Curators_PersonIdPerson",
                table: "Curators",
                column: "PersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentTypeDepartTypeID",
                table: "Departments",
                column: "DepartmentTypeDepartTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadDepartId",
                table: "Departments",
                column: "HeadDepartId");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_IdClassWork",
                table: "DoClassWorkAttends",
                column: "IdClassWork");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_WorkPersonStatusIdWPS",
                table: "DoClassWorkAttends",
                column: "WorkPersonStatusIdWPS");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_AuditoryDepartmentID",
                table: "ExactClasses",
                column: "AuditoryDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_ExactClassForLecturerClassIdEXCFLC",
                table: "ExactClasses",
                column: "ExactClassForLecturerClassIdEXCFLC");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_IdSFG",
                table: "ExactClasses",
                column: "IdSFG");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_LecturerIdSLecturer",
                table: "ExactClasses",
                column: "LecturerIdSLecturer");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_PersonLecturerIdPerson",
                table: "ExactClasses",
                column: "PersonLecturerIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_SubjectLecturerIdLecturer_SubjectLecturerIdSubject",
                table: "ExactClasses",
                columns: new[] { "SubjectLecturerIdLecturer", "SubjectLecturerIdSubject" });

            migrationBuilder.CreateIndex(
                name: "IX_ExactClassForLecturerClasses_LecturerIdSLecturer",
                table: "ExactClassForLecturerClasses",
                column: "LecturerIdSLecturer");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentGroupDepartmentID",
                table: "Groups",
                column: "DepartmentGroupDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupPrevIdGroup",
                table: "Groups",
                column: "GroupPrevIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyIdSpec",
                table: "Groups",
                column: "SpecialtyIdSpec");

            migrationBuilder.CreateIndex(
                name: "IX_Lectureres_PersonIdPerson",
                table: "Lectureres",
                column: "PersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdPerson",
                table: "Students",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories",
                column: "ConditionOfPersonIdConditionOfPerson");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_CourseIdCourse",
                table: "StudentsGroupHistories",
                column: "CourseIdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_GroupIdGroup",
                table: "StudentsGroupHistories",
                column: "GroupIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_IdStudent",
                table: "StudentsGroupHistories",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_StudyYearIdStudyYear",
                table: "StudentsGroupHistories",
                column: "StudyYearIdStudyYear");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanRecords_FacultetDepartmentID",
                table: "StudyPlanRecords",
                column: "FacultetDepartmentID");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_DepartmentID",
                table: "SubjectForGroups",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_IdCourse",
                table: "SubjectForGroups",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_IdGroup",
                table: "SubjectForGroups",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_IdPerson",
                table: "SubjectForGroups",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectForGroups_IdStudyPlan",
                table: "SubjectForGroups",
                column: "IdStudyPlan");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonIdPerson",
                table: "Users",
                column: "PersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roleid_role",
                table: "Users",
                column: "Roleid_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Curators");

            migrationBuilder.DropTable(
                name: "DoClassWorkAttends");

            migrationBuilder.DropTable(
                name: "SemestrBases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StudentsGroupHistories");

            migrationBuilder.DropTable(
                name: "TypeAttedances");

            migrationBuilder.DropTable(
                name: "ClassWorks");

            migrationBuilder.DropTable(
                name: "WorkPersonStatuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ConditionOfPersons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ExactClasses");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "ExactClassForLecturerClasses");

            migrationBuilder.DropTable(
                name: "SubjectForGroups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "StudyPlanRecords");

            migrationBuilder.DropTable(
                name: "SubjectLecturers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "StudyYears");

            migrationBuilder.DropTable(
                name: "TypeControls");

            migrationBuilder.DropTable(
                name: "TypeStudyPlanRecords");

            migrationBuilder.DropTable(
                name: "Lectureres");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TypeStudies");

            migrationBuilder.DropTable(
                name: "DepartmentTypes");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "dbo");
        }
    }
}
