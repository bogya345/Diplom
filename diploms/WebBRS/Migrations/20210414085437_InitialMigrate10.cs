using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialMigrate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoClassWorkAttends_Attendances_IdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropIndex(
                name: "IX_DoClassWorkAttends_IdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.DropColumn(
                name: "IdAtt",
                table: "DoClassWorkAttends");

            migrationBuilder.AddColumn<double>(
                name: "Ball",
                table: "Attendances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ClassWorkIdClassWork",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePass",
                table: "Attendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimePass",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextDoClassWork",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkPersonStatusIdWPS",
                table: "Attendances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClassWorkIdClassWork",
                table: "Attendances",
                column: "ClassWorkIdClassWork");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_WorkPersonStatusIdWPS",
                table: "Attendances",
                column: "WorkPersonStatusIdWPS");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_ClassWorks_ClassWorkIdClassWork",
                table: "Attendances",
                column: "ClassWorkIdClassWork",
                principalTable: "ClassWorks",
                principalColumn: "IdClassWork",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_WorkPersonStatuses_WorkPersonStatusIdWPS",
                table: "Attendances",
                column: "WorkPersonStatusIdWPS",
                principalTable: "WorkPersonStatuses",
                principalColumn: "IdWPS",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_ClassWorks_ClassWorkIdClassWork",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_WorkPersonStatuses_WorkPersonStatusIdWPS",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_ClassWorkIdClassWork",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_WorkPersonStatusIdWPS",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Ball",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "ClassWorkIdClassWork",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "DatePass",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "DateTimePass",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TextDoClassWork",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "WorkPersonStatusIdWPS",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "IdAtt",
                table: "DoClassWorkAttends",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_IdAtt",
                table: "DoClassWorkAttends",
                column: "IdAtt");

            migrationBuilder.AddForeignKey(
                name: "FK_DoClassWorkAttends_Attendances_IdAtt",
                table: "DoClassWorkAttends",
                column: "IdAtt",
                principalTable: "Attendances",
                principalColumn: "IdAtt",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
