using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class renameUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jalon_Utilisateur_AssigneeId",
                table: "Jalon");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Utilisateur_AssigneeId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilisateur",
                table: "Utilisateur");

            migrationBuilder.RenameTable(
                name: "Utilisateur",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jalon_User_AssigneeId",
                table: "Jalon",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jalon_User_AssigneeId",
                table: "Jalon");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Utilisateur");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilisateur",
                table: "Utilisateur",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jalon_Utilisateur_AssigneeId",
                table: "Jalon",
                column: "AssigneeId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Utilisateur_AssigneeId",
                table: "Task",
                column: "AssigneeId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
