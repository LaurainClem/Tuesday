using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class Exigence5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Jalon_JalonId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "ExigenceEntityTaskEntity");

            migrationBuilder.DropIndex(
                name: "IX_Task_JalonId",
                table: "Task");

            migrationBuilder.CreateTable(
                name: "TaskExigence",
                columns: table => new
                {
                    ExigenceId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskExigence");

            migrationBuilder.CreateTable(
                name: "ExigenceEntityTaskEntity",
                columns: table => new
                {
                    ExigencesId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExigenceEntityTaskEntity", x => new { x.ExigencesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_ExigenceEntityTaskEntity_Exigence_ExigencesId",
                        column: x => x.ExigencesId,
                        principalTable: "Exigence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExigenceEntityTaskEntity_Task_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_JalonId",
                table: "Task",
                column: "JalonId");

            migrationBuilder.CreateIndex(
                name: "IX_ExigenceEntityTaskEntity_TasksId",
                table: "ExigenceEntityTaskEntity",
                column: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Jalon_JalonId",
                table: "Task",
                column: "JalonId",
                principalTable: "Jalon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
