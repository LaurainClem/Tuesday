using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class userProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_AssigneeId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_AssigneeId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AssigneeId",
                table: "Project",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_AssigneeId",
                table: "Project",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
