using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassWorks_ExactClasses_ExactClassIdClass",
                table: "ClassWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassWorks_WorkTypes_WorkTypeIdWT",
                table: "ClassWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_HeadDepartIdDepart",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoClassWorkAttends_Attendances_AttendanceIdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropForeignKey(
                name: "FK_DoClassWorkAttends_ClassWorks_ClassWorkIdClassWork",
                table: "DoClassWorkAttends");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_SubjectForGroups_SubjectForGroupIdSFG",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Departments_DepartmentGroupIdDepart",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_GroupPrevIdGroup",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialties_SpecialtyIdSpec",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupHistories_Groups_GroupIdGroup",
                table: "StudentsGroupHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupHistories_Students_StudentIdStudent",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroupHistories_GroupIdGroup",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroupHistories_StudentIdStudent",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_Groups_DepartmentGroupIdDepart",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupPrevIdGroup",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialtyIdSpec",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_SubjectForGroupIdSFG",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_DoClassWorkAttends_AttendanceIdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropIndex(
                name: "IX_DoClassWorkAttends_ClassWorkIdClassWork",
                table: "DoClassWorkAttends");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadDepartIdDepart",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_ClassWorks_ExactClassIdClass",
                table: "ClassWorks");

            migrationBuilder.DropColumn(
                name: "GroupIdGroup",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "StudentIdStudent",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "GuidPerson",
                table: "Lectureres");

            migrationBuilder.DropColumn(
                name: "DepartmentGroupIdDepart",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupPrevIdGroup",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SpecialtyIdSpec",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SubjectForGroupIdSFG",
                table: "ExactClasses");

            migrationBuilder.DropColumn(
                name: "AttendanceIdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropColumn(
                name: "ClassWorkIdClassWork",
                table: "DoClassWorkAttends");

            migrationBuilder.DropColumn(
                name: "HeadDepartIdDepart",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ExactClassIdClass",
                table: "ClassWorks");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "ClassWorks");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IdSGH",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "WorkTypeIdWT",
                table: "ClassWorks",
                newName: "IdClasss");

            migrationBuilder.RenameIndex(
                name: "IX_ClassWorks_WorkTypeIdWT",
                table: "ClassWorks",
                newName: "IX_ClassWorks_IdClasss");

            migrationBuilder.AlterColumn<int>(
                name: "HeadDepartId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_IdGroup",
                table: "StudentsGroupHistories",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_IdStudent",
                table: "StudentsGroupHistories",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IdDepart",
                table: "Groups",
                column: "IdDepart");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IdGroupPrev",
                table: "Groups",
                column: "IdGroupPrev");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IdSpec",
                table: "Groups",
                column: "IdSpec");

            migrationBuilder.CreateIndex(
                name: "IX_ExactClasses_IdSFG",
                table: "ExactClasses",
                column: "IdSFG");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_IdAtt",
                table: "DoClassWorkAttends",
                column: "IdAtt");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_IdClassWork",
                table: "DoClassWorkAttends",
                column: "IdClassWork");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadDepartId",
                table: "Departments",
                column: "HeadDepartId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWorks_IdWT",
                table: "ClassWorks",
                column: "IdWT");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassWorks_ExactClasses_IdClasss",
                table: "ClassWorks",
                column: "IdClasss",
                principalTable: "ExactClasses",
                principalColumn: "IdClass",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassWorks_WorkTypes_IdWT",
                table: "ClassWorks",
                column: "IdWT",
                principalTable: "WorkTypes",
                principalColumn: "IdWT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_HeadDepartId",
                table: "Departments",
                column: "HeadDepartId",
                principalTable: "Departments",
                principalColumn: "IdDepart",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoClassWorkAttends_Attendances_IdAtt",
                table: "DoClassWorkAttends",
                column: "IdAtt",
                principalTable: "Attendances",
                principalColumn: "IdAtt",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoClassWorkAttends_ClassWorks_IdClassWork",
                table: "DoClassWorkAttends",
                column: "IdClassWork",
                principalTable: "ClassWorks",
                principalColumn: "IdClassWork",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_SubjectForGroups_IdSFG",
                table: "ExactClasses",
                column: "IdSFG",
                principalTable: "SubjectForGroups",
                principalColumn: "IdSFG",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Departments_IdDepart",
                table: "Groups",
                column: "IdDepart",
                principalTable: "Departments",
                principalColumn: "IdDepart",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_IdGroupPrev",
                table: "Groups",
                column: "IdGroupPrev",
                principalTable: "Groups",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialties_IdSpec",
                table: "Groups",
                column: "IdSpec",
                principalTable: "Specialties",
                principalColumn: "IdSpec",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupHistories_Groups_IdGroup",
                table: "StudentsGroupHistories",
                column: "IdGroup",
                principalTable: "Groups",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupHistories_Students_IdStudent",
                table: "StudentsGroupHistories",
                column: "IdStudent",
                principalTable: "Students",
                principalColumn: "IdStudent",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassWorks_ExactClasses_IdClasss",
                table: "ClassWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassWorks_WorkTypes_IdWT",
                table: "ClassWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_HeadDepartId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoClassWorkAttends_Attendances_IdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropForeignKey(
                name: "FK_DoClassWorkAttends_ClassWorks_IdClassWork",
                table: "DoClassWorkAttends");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_SubjectForGroups_IdSFG",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Departments_IdDepart",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_IdGroupPrev",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialties_IdSpec",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupHistories_Groups_IdGroup",
                table: "StudentsGroupHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupHistories_Students_IdStudent",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroupHistories_IdGroup",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroupHistories_IdStudent",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_Groups_IdDepart",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_IdGroupPrev",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_IdSpec",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_ExactClasses_IdSFG",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_DoClassWorkAttends_IdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropIndex(
                name: "IX_DoClassWorkAttends_IdClassWork",
                table: "DoClassWorkAttends");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadDepartId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_ClassWorks_IdWT",
                table: "ClassWorks");

            migrationBuilder.RenameColumn(
                name: "IdClasss",
                table: "ClassWorks",
                newName: "WorkTypeIdWT");

            migrationBuilder.RenameIndex(
                name: "IX_ClassWorks_IdClasss",
                table: "ClassWorks",
                newName: "IX_ClassWorks_WorkTypeIdWT");

            migrationBuilder.AddColumn<int>(
                name: "GroupIdGroup",
                table: "StudentsGroupHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentIdStudent",
                table: "StudentsGroupHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuidPerson",
                table: "Lectureres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentGroupIdDepart",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupPrevIdGroup",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyIdSpec",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectForGroupIdSFG",
                table: "ExactClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttendanceIdAtt",
                table: "DoClassWorkAttends",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassWorkIdClassWork",
                table: "DoClassWorkAttends",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HeadDepartId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadDepartIdDepart",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExactClassIdClass",
                table: "ClassWorks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClass",
                table: "ClassWorks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClass",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSGH",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_GroupIdGroup",
                table: "StudentsGroupHistories",
                column: "GroupIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_StudentIdStudent",
                table: "StudentsGroupHistories",
                column: "StudentIdStudent");

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
                name: "IX_ExactClasses_SubjectForGroupIdSFG",
                table: "ExactClasses",
                column: "SubjectForGroupIdSFG");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_AttendanceIdAtt",
                table: "DoClassWorkAttends",
                column: "AttendanceIdAtt");

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_ClassWorkIdClassWork",
                table: "DoClassWorkAttends",
                column: "ClassWorkIdClassWork");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadDepartIdDepart",
                table: "Departments",
                column: "HeadDepartIdDepart");

            migrationBuilder.CreateIndex(
                name: "IX_ClassWorks_ExactClassIdClass",
                table: "ClassWorks",
                column: "ExactClassIdClass");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassWorks_ExactClasses_ExactClassIdClass",
                table: "ClassWorks",
                column: "ExactClassIdClass",
                principalTable: "ExactClasses",
                principalColumn: "IdClass",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassWorks_WorkTypes_WorkTypeIdWT",
                table: "ClassWorks",
                column: "WorkTypeIdWT",
                principalTable: "WorkTypes",
                principalColumn: "IdWT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_HeadDepartIdDepart",
                table: "Departments",
                column: "HeadDepartIdDepart",
                principalTable: "Departments",
                principalColumn: "IdDepart",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoClassWorkAttends_Attendances_AttendanceIdAtt",
                table: "DoClassWorkAttends",
                column: "AttendanceIdAtt",
                principalTable: "Attendances",
                principalColumn: "IdAtt",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoClassWorkAttends_ClassWorks_ClassWorkIdClassWork",
                table: "DoClassWorkAttends",
                column: "ClassWorkIdClassWork",
                principalTable: "ClassWorks",
                principalColumn: "IdClassWork",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_SubjectForGroups_SubjectForGroupIdSFG",
                table: "ExactClasses",
                column: "SubjectForGroupIdSFG",
                principalTable: "SubjectForGroups",
                principalColumn: "IdSFG",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Departments_DepartmentGroupIdDepart",
                table: "Groups",
                column: "DepartmentGroupIdDepart",
                principalTable: "Departments",
                principalColumn: "IdDepart",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_GroupPrevIdGroup",
                table: "Groups",
                column: "GroupPrevIdGroup",
                principalTable: "Groups",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialties_SpecialtyIdSpec",
                table: "Groups",
                column: "SpecialtyIdSpec",
                principalTable: "Specialties",
                principalColumn: "IdSpec",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupHistories_Groups_GroupIdGroup",
                table: "StudentsGroupHistories",
                column: "GroupIdGroup",
                principalTable: "Groups",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupHistories_Students_StudentIdStudent",
                table: "StudentsGroupHistories",
                column: "StudentIdStudent",
                principalTable: "Students",
                principalColumn: "IdStudent",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
