using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class JalonUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Jalon_JalonId",
                table: "Exigence");

            migrationBuilder.DropForeignKey(
                name: "FK_Jalon_User_AssigneeId",
                table: "Jalon");

            migrationBuilder.RenameColumn(
                name: "JalonId",
                table: "Exigence",
                newName: "JalonID");

            migrationBuilder.RenameIndex(
                name: "IX_Exigence_JalonId",
                table: "Exigence",
                newName: "IX_Exigence_JalonID");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Jalon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JalonID",
                table: "Exigence",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Exigence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_ProjectId",
                table: "Exigence",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Jalon_JalonID",
                table: "Exigence",
                column: "JalonID",
                principalTable: "Jalon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Project_ProjectId",
                table: "Exigence",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jalon_User_AssigneeId",
                table: "Jalon",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Jalon_JalonID",
                table: "Exigence");

            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Project_ProjectId",
                table: "Exigence");

            migrationBuilder.DropForeignKey(
                name: "FK_Jalon_User_AssigneeId",
                table: "Jalon");

            migrationBuilder.DropIndex(
                name: "IX_Exigence_ProjectId",
                table: "Exigence");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Exigence");

            migrationBuilder.RenameColumn(
                name: "JalonID",
                table: "Exigence",
                newName: "JalonId");

            migrationBuilder.RenameIndex(
                name: "IX_Exigence_JalonID",
                table: "Exigence",
                newName: "IX_Exigence_JalonId");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Jalon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JalonId",
                table: "Exigence",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Jalon_JalonId",
                table: "Exigence",
                column: "JalonId",
                principalTable: "Jalon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jalon_User_AssigneeId",
                table: "Jalon",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
