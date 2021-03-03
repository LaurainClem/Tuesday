using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class Exigence3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Jalon_JalonID",
                table: "Exigence");

            migrationBuilder.AlterColumn<int>(
                name: "JalonID",
                table: "Exigence",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Jalon_JalonID",
                table: "Exigence",
                column: "JalonID",
                principalTable: "Jalon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Jalon_JalonID",
                table: "Exigence");

            migrationBuilder.AlterColumn<int>(
                name: "JalonID",
                table: "Exigence",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Jalon_JalonID",
                table: "Exigence",
                column: "JalonID",
                principalTable: "Jalon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
