using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class renameEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Tache_TacheEntityId",
                table: "Exigence");

            migrationBuilder.DropForeignKey(
                name: "FK_Jalon_Projet_ProjetEntityId",
                table: "Jalon");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "Tache");

            migrationBuilder.RenameColumn(
                name: "ProjetEntityId",
                table: "Jalon",
                newName: "ProjectEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Jalon_ProjetEntityId",
                table: "Jalon",
                newName: "IX_Jalon_ProjectEntityId");

            migrationBuilder.RenameColumn(
                name: "TacheEntityId",
                table: "Exigence",
                newName: "TaskEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Exigence_TacheEntityId",
                table: "Exigence",
                newName: "IX_Exigence_TaskEntityId");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    AssigneeId = table.Column<int>(type: "int", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    RequiredTaskId = table.Column<int>(type: "int", nullable: true),
                    JalonEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Jalon_JalonEntityId",
                        column: x => x.JalonEntityId,
                        principalTable: "Jalon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Task_RequiredTaskId",
                        column: x => x.RequiredTaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Utilisateur_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_AssigneeId",
                table: "Task",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_JalonEntityId",
                table: "Task",
                column: "JalonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_RequiredTaskId",
                table: "Task",
                column: "RequiredTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Task_TaskEntityId",
                table: "Exigence",
                column: "TaskEntityId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jalon_Project_ProjectEntityId",
                table: "Jalon",
                column: "ProjectEntityId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exigence_Task_TaskEntityId",
                table: "Exigence");

            migrationBuilder.DropForeignKey(
                name: "FK_Jalon_Project_ProjectEntityId",
                table: "Jalon");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.RenameColumn(
                name: "ProjectEntityId",
                table: "Jalon",
                newName: "ProjetEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Jalon_ProjectEntityId",
                table: "Jalon",
                newName: "IX_Jalon_ProjetEntityId");

            migrationBuilder.RenameColumn(
                name: "TaskEntityId",
                table: "Exigence",
                newName: "TacheEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Exigence_TaskEntityId",
                table: "Exigence",
                newName: "IX_Exigence_TacheEntityId");

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tache",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AssigneeId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    JalonEntityId = table.Column<int>(type: "int", nullable: true),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequiredTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tache", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tache_Jalon_JalonEntityId",
                        column: x => x.JalonEntityId,
                        principalTable: "Jalon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tache_Tache_RequiredTaskId",
                        column: x => x.RequiredTaskId,
                        principalTable: "Tache",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tache_Utilisateur_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tache_AssigneeId",
                table: "Tache",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tache_JalonEntityId",
                table: "Tache",
                column: "JalonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tache_RequiredTaskId",
                table: "Tache",
                column: "RequiredTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exigence_Tache_TacheEntityId",
                table: "Exigence",
                column: "TacheEntityId",
                principalTable: "Tache",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jalon_Projet_ProjetEntityId",
                table: "Jalon",
                column: "ProjetEntityId",
                principalTable: "Projet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
