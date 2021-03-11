using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    id_employee = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_department = table.Column<int>(type: "int", nullable: false),
                    name_department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_role = table.Column<int>(type: "int", nullable: false),
                    name_role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_role_actual = table.Column<int>(type: "int", nullable: false),
                    name_role_actual = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsers");
        }
    }
}
