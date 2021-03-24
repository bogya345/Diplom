﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBRS.DAL;

namespace WebBRS.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210324084348_InitialCreate7")]
    partial class InitialCreate7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebBRS.Models.Attendance", b =>
                {
                    b.Property<int>("IdAtt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExactClassIdClass")
                        .HasColumnType("int");

                    b.Property<int?>("SGHIdSGH")
                        .HasColumnType("int");

                    b.HasKey("IdAtt");

                    b.HasIndex("ExactClassIdClass");

                    b.HasIndex("SGHIdSGH");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("WebBRS.Models.Auth.Role", b =>
                {
                    b.Property<int>("id_role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name_role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_role");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebBRS.Models.Auth.User", b =>
                {
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("PersonGuidPerson")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Roleid_role")
                        .HasColumnType("int");

                    b.HasKey("id_user");

                    b.HasIndex("PersonGuidPerson");

                    b.HasIndex("Roleid_role");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebBRS.Models.ClassWork", b =>
                {
                    b.Property<int>("IdClassWork")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateGiven")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePathWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdClasss")
                        .HasColumnType("int");

                    b.Property<int?>("IdWT")
                        .HasColumnType("int");

                    b.Property<double>("MaxBall")
                        .HasColumnType("float");

                    b.Property<string>("TextWork")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClassWork");

                    b.HasIndex("IdClasss");

                    b.HasIndex("IdWT");

                    b.ToTable("ClassWorks");
                });

            modelBuilder.Entity("WebBRS.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DepartmentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("FullNameDepart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HeadDepartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortNameDepart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentGUID");

                    b.HasIndex("DepartmentTypeID");

                    b.HasIndex("HeadDepartId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WebBRS.Models.DepartmentType", b =>
                {
                    b.Property<int>("DepartTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullDepartTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDepartTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartTypeID");

                    b.ToTable("DepartmentTypes");
                });

            modelBuilder.Entity("WebBRS.Models.DoClassWorkAttend", b =>
                {
                    b.Property<int>("IdDCWA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Ball")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DatePass")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimePass")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdAtt")
                        .HasColumnType("int");

                    b.Property<int?>("IdClassWork")
                        .HasColumnType("int");

                    b.Property<int?>("IdWPS")
                        .HasColumnType("int");

                    b.Property<string>("TextDoClassWork")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDCWA");

                    b.HasIndex("IdAtt");

                    b.HasIndex("IdClassWork");

                    b.HasIndex("IdWPS");

                    b.ToTable("DoClassWorkAttends");
                });

            modelBuilder.Entity("WebBRS.Models.ExactClass", b =>
                {
                    b.Property<int>("IdClass")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ClassNumber")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("DateClassEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateClassStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExactClassForLecturerClassIdEXCFLC")
                        .HasColumnType("int");

                    b.Property<int?>("IdSFG")
                        .HasColumnType("int");

                    b.Property<int?>("LecturerIdSLecturer")
                        .HasColumnType("int");

                    b.Property<Guid?>("PersonLecturerGuidPerson")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SubjectLecturerIdLecturer")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectLecturerIdSubject")
                        .HasColumnType("int");

                    b.HasKey("IdClass");

                    b.HasIndex("ExactClassForLecturerClassIdEXCFLC");

                    b.HasIndex("IdSFG");

                    b.HasIndex("LecturerIdSLecturer");

                    b.HasIndex("PersonLecturerGuidPerson");

                    b.HasIndex("SubjectLecturerIdLecturer", "SubjectLecturerIdSubject");

                    b.ToTable("ExactClasses");
                });

            modelBuilder.Entity("WebBRS.Models.ExactClassForLecturerClass", b =>
                {
                    b.Property<int>("IdEXCFLC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("ClassNumber")
                        .HasColumnType("tinyint");

                    b.Property<int?>("LecturerIdSLecturer")
                        .HasColumnType("int");

                    b.HasKey("IdEXCFLC");

                    b.HasIndex("LecturerIdSLecturer");

                    b.ToTable("ExactClassForLecturerClasses");
                });

            modelBuilder.Entity("WebBRS.Models.Group", b =>
                {
                    b.Property<int>("IdGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateExit")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdDepart")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IdGroupPrev")
                        .HasColumnType("int");

                    b.Property<int?>("IdSpec")
                        .HasColumnType("int");

                    b.HasKey("IdGroup");

                    b.HasIndex("IdDepart");

                    b.HasIndex("IdGroupPrev");

                    b.HasIndex("IdSpec");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("WebBRS.Models.Lecturer", b =>
                {
                    b.Property<int>("IdSLecturer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("PersonGuidPerson")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdSLecturer");

                    b.HasIndex("PersonGuidPerson");

                    b.ToTable("Lectureres");
                });

            modelBuilder.Entity("WebBRS.Models.Person", b =>
                {
                    b.Property<Guid>("GuidPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeReg")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatronicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("nCode")
                        .HasColumnType("int");

                    b.HasKey("GuidPerson");

                    b.ToTable("Persons", "dbo");
                });

            modelBuilder.Entity("WebBRS.Models.Specialty", b =>
                {
                    b.Property<int>("IdSpec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameSpec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortNameSpec")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSpec");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("WebBRS.Models.Student", b =>
                {
                    b.Property<int>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("GuidPerson")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZachNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStudent");

                    b.HasIndex("GuidPerson");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebBRS.Models.StudentsGroupHistory", b =>
                {
                    b.Property<int>("IdSGH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSGHFinished")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSGHStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdGroup")
                        .HasColumnType("int");

                    b.Property<int?>("IdStudent")
                        .HasColumnType("int");

                    b.HasKey("IdSGH");

                    b.HasIndex("IdGroup");

                    b.HasIndex("IdStudent");

                    b.ToTable("StudentsGroupHistories");
                });

            modelBuilder.Entity("WebBRS.Models.Subject", b =>
                {
                    b.Property<int>("IdSubject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeSubject")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSubject");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WebBRS.Models.SubjectForGroup", b =>
                {
                    b.Property<int>("IdSFG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdGroup")
                        .HasColumnType("int");

                    b.Property<int?>("IdSubject")
                        .HasColumnType("int");

                    b.Property<int?>("LecturerIdLecturer")
                        .HasColumnType("int");

                    b.Property<int?>("LecturerIdSLecturer")
                        .HasColumnType("int");

                    b.Property<int?>("LecturerIdSubject")
                        .HasColumnType("int");

                    b.Property<DateTime>("SFGDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TypeStudyIdTS")
                        .HasColumnType("int");

                    b.HasKey("IdSFG");

                    b.HasIndex("IdGroup");

                    b.HasIndex("IdSubject");

                    b.HasIndex("LecturerIdSLecturer");

                    b.HasIndex("TypeStudyIdTS");

                    b.HasIndex("LecturerIdLecturer", "LecturerIdSubject");

                    b.ToTable("SubjectForGroups");
                });

            modelBuilder.Entity("WebBRS.Models.SubjectLecturer", b =>
                {
                    b.Property<int>("IdLecturer")
                        .HasColumnType("int");

                    b.Property<int>("IdSubject")
                        .HasColumnType("int");

                    b.Property<int>("IdTS")
                        .HasColumnType("int");

                    b.Property<DateTime>("SLDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("IdLecturer", "IdSubject");

                    b.HasIndex("IdSubject");

                    b.HasIndex("IdTS");

                    b.ToTable("SubjectLecturers");
                });

            modelBuilder.Entity("WebBRS.Models.TypeStudy", b =>
                {
                    b.Property<int>("IdTS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShortTypeStudyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeStudyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTS");

                    b.ToTable("TypeStudy");
                });

            modelBuilder.Entity("WebBRS.Models.Views.AuthUsers", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_department")
                        .HasColumnType("int");

                    b.Property<int>("id_employee")
                        .HasColumnType("int");

                    b.Property<int>("id_role")
                        .HasColumnType("int");

                    b.Property<int>("id_role_actual")
                        .HasColumnType("int");

                    b.Property<string>("name_department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_role_actual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("AuthUsers");
                });

            modelBuilder.Entity("WebBRS.Models.WorkPersonStatus", b =>
                {
                    b.Property<int>("IdWPS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WorkpersonStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkpersonStatusNameShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWPS");

                    b.ToTable("WorkPersonStatuses");
                });

            modelBuilder.Entity("WebBRS.Models.WorkType", b =>
                {
                    b.Property<int>("IdWT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShortWorkTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWT");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("WebBRS.Models.Attendance", b =>
                {
                    b.HasOne("WebBRS.Models.ExactClass", "ExactClass")
                        .WithMany("Attendances")
                        .HasForeignKey("ExactClassIdClass");

                    b.HasOne("WebBRS.Models.StudentsGroupHistory", "SGH")
                        .WithMany("Attendances")
                        .HasForeignKey("SGHIdSGH");

                    b.Navigation("ExactClass");

                    b.Navigation("SGH");
                });

            modelBuilder.Entity("WebBRS.Models.Auth.User", b =>
                {
                    b.HasOne("WebBRS.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonGuidPerson");

                    b.HasOne("WebBRS.Models.Auth.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Roleid_role");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebBRS.Models.ClassWork", b =>
                {
                    b.HasOne("WebBRS.Models.ExactClass", "ExactClass")
                        .WithMany("ClassWorks")
                        .HasForeignKey("IdClasss");

                    b.HasOne("WebBRS.Models.WorkType", "WorkType")
                        .WithMany("ClassWorks")
                        .HasForeignKey("IdWT");

                    b.Navigation("ExactClass");

                    b.Navigation("WorkType");
                });

            modelBuilder.Entity("WebBRS.Models.Department", b =>
                {
                    b.HasOne("WebBRS.Models.DepartmentType", "DepartmentType")
                        .WithMany("Departments")
                        .HasForeignKey("DepartmentTypeID");

                    b.HasOne("WebBRS.Models.Department", "HeadDepart")
                        .WithMany("Departments")
                        .HasForeignKey("HeadDepartId");

                    b.Navigation("DepartmentType");

                    b.Navigation("HeadDepart");
                });

            modelBuilder.Entity("WebBRS.Models.DoClassWorkAttend", b =>
                {
                    b.HasOne("WebBRS.Models.Attendance", "Attendance")
                        .WithMany("DoClassWorkAttends")
                        .HasForeignKey("IdAtt");

                    b.HasOne("WebBRS.Models.ClassWork", "ClassWork")
                        .WithMany("DoClassWorkAttends")
                        .HasForeignKey("IdClassWork");

                    b.HasOne("WebBRS.Models.WorkPersonStatus", "WorkPersonStatus")
                        .WithMany()
                        .HasForeignKey("IdWPS");

                    b.Navigation("Attendance");

                    b.Navigation("ClassWork");

                    b.Navigation("WorkPersonStatus");
                });

            modelBuilder.Entity("WebBRS.Models.ExactClass", b =>
                {
                    b.HasOne("WebBRS.Models.ExactClassForLecturerClass", "ExactClassForLecturerClass")
                        .WithMany("ExactClasses")
                        .HasForeignKey("ExactClassForLecturerClassIdEXCFLC");

                    b.HasOne("WebBRS.Models.SubjectForGroup", "SubjectForGroup")
                        .WithMany("ExactClasses")
                        .HasForeignKey("IdSFG");

                    b.HasOne("WebBRS.Models.Lecturer", null)
                        .WithMany("ExactClasses")
                        .HasForeignKey("LecturerIdSLecturer");

                    b.HasOne("WebBRS.Models.Person", "PersonLecturer")
                        .WithMany()
                        .HasForeignKey("PersonLecturerGuidPerson");

                    b.HasOne("WebBRS.Models.SubjectLecturer", "SubjectLecturer")
                        .WithMany()
                        .HasForeignKey("SubjectLecturerIdLecturer", "SubjectLecturerIdSubject");

                    b.Navigation("ExactClassForLecturerClass");

                    b.Navigation("PersonLecturer");

                    b.Navigation("SubjectForGroup");

                    b.Navigation("SubjectLecturer");
                });

            modelBuilder.Entity("WebBRS.Models.ExactClassForLecturerClass", b =>
                {
                    b.HasOne("WebBRS.Models.Lecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerIdSLecturer");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("WebBRS.Models.Group", b =>
                {
                    b.HasOne("WebBRS.Models.Department", "DepartmentGroup")
                        .WithMany("Groups")
                        .HasForeignKey("IdDepart");

                    b.HasOne("WebBRS.Models.Group", "GroupPrev")
                        .WithMany("PrevGroups")
                        .HasForeignKey("IdGroupPrev");

                    b.HasOne("WebBRS.Models.Specialty", "Specialty")
                        .WithMany("Groups")
                        .HasForeignKey("IdSpec");

                    b.Navigation("DepartmentGroup");

                    b.Navigation("GroupPrev");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("WebBRS.Models.Lecturer", b =>
                {
                    b.HasOne("WebBRS.Models.Person", "Person")
                        .WithMany("Lecturers")
                        .HasForeignKey("PersonGuidPerson");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebBRS.Models.Student", b =>
                {
                    b.HasOne("WebBRS.Models.Person", "Person")
                        .WithMany("Students")
                        .HasForeignKey("GuidPerson");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebBRS.Models.StudentsGroupHistory", b =>
                {
                    b.HasOne("WebBRS.Models.Group", "Group")
                        .WithMany("StudentsGroupHistories")
                        .HasForeignKey("IdGroup");

                    b.HasOne("WebBRS.Models.Student", "Student")
                        .WithMany("StudentsGroupHistories")
                        .HasForeignKey("IdStudent");

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebBRS.Models.SubjectForGroup", b =>
                {
                    b.HasOne("WebBRS.Models.Group", "Group")
                        .WithMany("SubjectForGroups")
                        .HasForeignKey("IdGroup");

                    b.HasOne("WebBRS.Models.Subject", "Subject")
                        .WithMany("SubjectForGroups")
                        .HasForeignKey("IdSubject");

                    b.HasOne("WebBRS.Models.Lecturer", null)
                        .WithMany("SubjectForGroups")
                        .HasForeignKey("LecturerIdSLecturer");

                    b.HasOne("WebBRS.Models.TypeStudy", "TypeStudy")
                        .WithMany("SubjectForGroups")
                        .HasForeignKey("TypeStudyIdTS");

                    b.HasOne("WebBRS.Models.SubjectLecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerIdLecturer", "LecturerIdSubject");

                    b.Navigation("Group");

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");

                    b.Navigation("TypeStudy");
                });

            modelBuilder.Entity("WebBRS.Models.SubjectLecturer", b =>
                {
                    b.HasOne("WebBRS.Models.Lecturer", "Lecturer")
                        .WithMany("SubjectLecturers")
                        .HasForeignKey("IdLecturer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBRS.Models.Subject", "Subject")
                        .WithMany("SubjectLecturers")
                        .HasForeignKey("IdSubject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBRS.Models.TypeStudy", "TypeStudy")
                        .WithMany("SubjectLecturers")
                        .HasForeignKey("IdTS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");

                    b.Navigation("TypeStudy");
                });

            modelBuilder.Entity("WebBRS.Models.Attendance", b =>
                {
                    b.Navigation("DoClassWorkAttends");
                });

            modelBuilder.Entity("WebBRS.Models.ClassWork", b =>
                {
                    b.Navigation("DoClassWorkAttends");
                });

            modelBuilder.Entity("WebBRS.Models.Department", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("WebBRS.Models.DepartmentType", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("WebBRS.Models.ExactClass", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("ClassWorks");
                });

            modelBuilder.Entity("WebBRS.Models.ExactClassForLecturerClass", b =>
                {
                    b.Navigation("ExactClasses");
                });

            modelBuilder.Entity("WebBRS.Models.Group", b =>
                {
                    b.Navigation("PrevGroups");

                    b.Navigation("StudentsGroupHistories");

                    b.Navigation("SubjectForGroups");
                });

            modelBuilder.Entity("WebBRS.Models.Lecturer", b =>
                {
                    b.Navigation("ExactClasses");

                    b.Navigation("SubjectForGroups");

                    b.Navigation("SubjectLecturers");
                });

            modelBuilder.Entity("WebBRS.Models.Person", b =>
                {
                    b.Navigation("Lecturers");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("WebBRS.Models.Specialty", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("WebBRS.Models.Student", b =>
                {
                    b.Navigation("StudentsGroupHistories");
                });

            modelBuilder.Entity("WebBRS.Models.StudentsGroupHistory", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("WebBRS.Models.Subject", b =>
                {
                    b.Navigation("SubjectForGroups");

                    b.Navigation("SubjectLecturers");
                });

            modelBuilder.Entity("WebBRS.Models.SubjectForGroup", b =>
                {
                    b.Navigation("ExactClasses");
                });

            modelBuilder.Entity("WebBRS.Models.TypeStudy", b =>
                {
                    b.Navigation("SubjectForGroups");

                    b.Navigation("SubjectLecturers");
                });

            modelBuilder.Entity("WebBRS.Models.WorkType", b =>
                {
                    b.Navigation("ClassWorks");
                });
#pragma warning restore 612, 618
        }
    }
}
