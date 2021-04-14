using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialMigrate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Curators_GroupIdGroup",
                table: "Curators",
                column: "GroupIdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Curators_PersonIdPerson",
                table: "Curators",
                column: "PersonIdPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curators");
        }
    }
}
