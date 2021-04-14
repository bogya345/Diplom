using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialMigrate8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAttedanceIdTA",
                table: "Attendances",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TypeAttedanceIdTA",
                table: "Attendances",
                column: "TypeAttedanceIdTA");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                table: "Attendances",
                column: "TypeAttedanceIdTA",
                principalTable: "TypeAttedances",
                principalColumn: "IdTA",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                table: "Attendances");

            migrationBuilder.DropTable(
                name: "TypeAttedances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_TypeAttedanceIdTA",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TypeAttedanceIdTA",
                table: "Attendances");
        }
    }
}
