using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class Exigence6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskExigence");

            migrationBuilder.AddColumn<int>(
                name: "TaskEntityId",
                table: "Exigence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_TaskEntityId",
                table: "Exigence",
                column: "TaskEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Task_TaskEntityId",
                table: "Exigence",
                column: "TaskEntityId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Task_TaskEntityId",
                table: "Exigence");

            migrationBuilder.DropIndex(
                name: "IX_Exigence_TaskEntityId",
                table: "Exigence");

            migrationBuilder.DropColumn(
                name: "TaskEntityId",
                table: "Exigence");

            migrationBuilder.CreateTable(
                name: "TaskExigence",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ExigenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskExigence", x => new { x.TaskId, x.ExigenceId });
                    table.ForeignKey(
                        name: "FK_TaskExigence_Exigence_ExigenceId",
                        column: x => x.ExigenceId,
                        principalTable: "Exigence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskExigence_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskExigence_ExigenceId",
                table: "TaskExigence",
                column: "ExigenceId");
        }
    }
}
