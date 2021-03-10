using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePass",
                table: "DoClassWorkAttends",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdWPS",
                table: "DoClassWorkAttends",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateGiven",
                table: "ClassWorks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "WorkPersonStatuses",
                columns: table => new
                {
                    IdWPS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkpersonStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkpersonStatusNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPersonStatuses", x => x.IdWPS);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoClassWorkAttends_IdWPS",
                table: "DoClassWorkAttends",
                column: "IdWPS");

            migrationBuilder.AddForeignKey(
                name: "FK_DoClassWorkAttends_WorkPersonStatuses_IdWPS",
                table: "DoClassWorkAttends",
                column: "IdWPS",
                principalTable: "WorkPersonStatuses",
                principalColumn: "IdWPS",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoClassWorkAttends_WorkPersonStatuses_IdWPS",
                table: "DoClassWorkAttends");

            migrationBuilder.DropTable(
                name: "WorkPersonStatuses");

            migrationBuilder.DropIndex(
                name: "IX_DoClassWorkAttends_IdWPS",
                table: "DoClassWorkAttends");

            migrationBuilder.DropColumn(
                name: "DatePass",
                table: "DoClassWorkAttends");

            migrationBuilder.DropColumn(
                name: "IdWPS",
                table: "DoClassWorkAttends");

            migrationBuilder.DropColumn(
                name: "DateGiven",
                table: "ClassWorks");
        }
    }
}
