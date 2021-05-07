using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBRS.Migrations
{
    public partial class CreateDB7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Attendances_ExactClasses_ExactClassIdClass",
            //    table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_StudentsGroupHistories_IdAtt",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                table: "Attendances");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ExactClasses_DraftTimeTable_DraftTimeTableIdDFTT",
            //    table: "ExactClasses");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ExactClasses_TypeTimeTable_TypeTimeTableidTTT",
            //    table: "ExactClasses");

            //migrationBuilder.DropColumn(
            //    name: "IdStudyYear",
            //    table: "DraftTimeTable");

            //migrationBuilder.AlterColumn<int>(
            //    name: "TypeTimeTableidTTT",
            //    table: "ExactClasses",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "DraftTimeTableIdDFTT",
            //    table: "ExactClasses",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "TypeAttedanceIdTA",
            //    table: "Attendances",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "ExactClassIdClass",
            //    table: "Attendances",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "IdAtt",
            //    table: "Attendances",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdSGH",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_IdSGH",
                table: "Attendances",
                column: "IdSGH");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_ExactClasses_ExactClassIdClass",
                table: "Attendances",
                column: "ExactClassIdClass",
                principalTable: "ExactClasses",
                principalColumn: "IdClass",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_StudentsGroupHistories_IdSGH",
                table: "Attendances",
                column: "IdSGH",
                principalTable: "StudentsGroupHistories",
                principalColumn: "IdSGH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                table: "Attendances",
                column: "TypeAttedanceIdTA",
                principalTable: "TypeAttedances",
                principalColumn: "IdTA",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ExactClasses_DraftTimeTable_DraftTimeTableIdDFTT",
            //    table: "ExactClasses",
            //    column: "DraftTimeTableIdDFTT",
            //    principalTable: "DraftTimeTable",
            //    principalColumn: "IdDFTT",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ExactClasses_TypeTimeTable_TypeTimeTableidTTT",
            //    table: "ExactClasses",
            //    column: "TypeTimeTableidTTT",
            //    principalTable: "TypeTimeTable",
            //    principalColumn: "idTTT",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_ExactClasses_ExactClassIdClass",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_StudentsGroupHistories_IdSGH",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_DraftTimeTable_DraftTimeTableIdDFTT",
                table: "ExactClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExactClasses_TypeTimeTable_TypeTimeTableidTTT",
                table: "ExactClasses");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_IdSGH",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IdSGH",
                table: "Attendances");

            migrationBuilder.AlterColumn<int>(
                name: "TypeTimeTableidTTT",
                table: "ExactClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DraftTimeTableIdDFTT",
                table: "ExactClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdStudyYear",
                table: "DraftTimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TypeAttedanceIdTA",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExactClassIdClass",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAtt",
                table: "Attendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_ExactClasses_ExactClassIdClass",
                table: "Attendances",
                column: "ExactClassIdClass",
                principalTable: "ExactClasses",
                principalColumn: "IdClass",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_StudentsGroupHistories_IdAtt",
                table: "Attendances",
                column: "IdAtt",
                principalTable: "StudentsGroupHistories",
                principalColumn: "IdSGH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_TypeAttedances_TypeAttedanceIdTA",
                table: "Attendances",
                column: "TypeAttedanceIdTA",
                principalTable: "TypeAttedances",
                principalColumn: "IdTA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_DraftTimeTable_DraftTimeTableIdDFTT",
                table: "ExactClasses",
                column: "DraftTimeTableIdDFTT",
                principalTable: "DraftTimeTable",
                principalColumn: "IdDFTT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExactClasses_TypeTimeTable_TypeTimeTableidTTT",
                table: "ExactClasses",
                column: "TypeTimeTableidTTT",
                principalTable: "TypeTimeTable",
                principalColumn: "idTTT",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
