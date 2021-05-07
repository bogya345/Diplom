using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectForGroups_StudyPlanRecords_IdStudyPlan",
                table: "SubjectForGroups");

            migrationBuilder.AlterColumn<int>(
                name: "IdStudyPlan",
                table: "SubjectForGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_reff",
                table: "SubjectForGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_reff",
                table: "ExactClasses",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectForGroups_StudyPlanRecords_IdStudyPlan",
                table: "SubjectForGroups",
                column: "IdStudyPlan",
                principalTable: "StudyPlanRecords",
                principalColumn: "IdStudyPlan",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectForGroups_StudyPlanRecords_IdStudyPlan",
                table: "SubjectForGroups");

            migrationBuilder.DropColumn(
                name: "ID_reff",
                table: "SubjectForGroups");

            migrationBuilder.DropColumn(
                name: "ID_reff",
                table: "ExactClasses");

            migrationBuilder.AlterColumn<int>(
                name: "IdStudyPlan",
                table: "SubjectForGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectForGroups_StudyPlanRecords_IdStudyPlan",
                table: "SubjectForGroups",
                column: "IdStudyPlan",
                principalTable: "StudyPlanRecords",
                principalColumn: "IdStudyPlan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
