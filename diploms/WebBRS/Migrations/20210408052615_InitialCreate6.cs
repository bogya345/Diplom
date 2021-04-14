using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSGHFinished",
                table: "StudentsGroupHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_1c_CounditionOfPerson",
                table: "StudentsGroupHistories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_1c_Course",
                table: "StudentsGroupHistories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_1c_Group",
                table: "StudentsGroupHistories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_1c_Person",
                table: "StudentsGroupHistories",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupHistories_ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories",
                column: "ConditionOfPersonIdConditionOfPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupHistories_ConditionOfPersons_ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories",
                column: "ConditionOfPersonIdConditionOfPerson",
                principalTable: "ConditionOfPersons",
                principalColumn: "IdConditionOfPerson",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupHistories_ConditionOfPersons_ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroupHistories_ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "ConditionOfPersonIdConditionOfPerson",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "ID_1c_CounditionOfPerson",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "ID_1c_Course",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "ID_1c_Group",
                table: "StudentsGroupHistories");

            migrationBuilder.DropColumn(
                name: "ID_1c_Person",
                table: "StudentsGroupHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSGHFinished",
                table: "StudentsGroupHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
