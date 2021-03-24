using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_role",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Roleid_role",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roleid_role",
                table: "Users",
                column: "Roleid_role");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Roleid_role",
                table: "Users",
                column: "Roleid_role",
                principalTable: "Roles",
                principalColumn: "id_role",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Roleid_role",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Roleid_role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Roleid_role",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "id_role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
