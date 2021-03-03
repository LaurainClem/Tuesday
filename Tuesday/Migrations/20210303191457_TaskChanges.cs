using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class TaskChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Task_TaskEntityId",
                table: "Exigence");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Jalon_JalonEntityId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_JalonEntityId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Exigence_TaskEntityId",
                table: "Exigence");

            migrationBuilder.DropColumn(
                name: "JalonEntityId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskEntityId",
                table: "Exigence");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JalonId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RealEndDate",
                table: "Task",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Jalon_JalonId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "ExigenceEntityTaskEntity");

            migrationBuilder.DropIndex(
                name: "IX_Task_JalonId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "JalonId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "RealEndDate",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JalonEntityId",
                table: "Task",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskEntityId",
                table: "Exigence",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_JalonEntityId",
                table: "Task",
                column: "JalonEntityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Jalon_JalonEntityId",
                table: "Task",
                column: "JalonEntityId",
                principalTable: "Jalon",
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
    }
}
