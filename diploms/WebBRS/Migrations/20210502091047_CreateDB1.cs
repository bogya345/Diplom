using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoditelIdTSPR",
                table: "TypeStudyPlanRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeStudyPlanRecords_RoditelIdTSPR",
                table: "TypeStudyPlanRecords",
                column: "RoditelIdTSPR");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeStudyPlanRecords_TypeStudyPlanRecords_RoditelIdTSPR",
                table: "TypeStudyPlanRecords",
                column: "RoditelIdTSPR",
                principalTable: "TypeStudyPlanRecords",
                principalColumn: "IdTSPR",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeStudyPlanRecords_TypeStudyPlanRecords_RoditelIdTSPR",
                table: "TypeStudyPlanRecords");

            migrationBuilder.DropIndex(
                name: "IX_TypeStudyPlanRecords_RoditelIdTSPR",
                table: "TypeStudyPlanRecords");

            migrationBuilder.DropColumn(
                name: "RoditelIdTSPR",
                table: "TypeStudyPlanRecords");
        }
    }
}
