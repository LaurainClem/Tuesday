using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuesday.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FirstName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    RequiredTaskId = table.Column<int>(type: "int", nullable: true),
                    JalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Task_RequiredTaskId",
                        column: x => x.RequiredTaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_User_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jalon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RealEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jalon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jalon_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jalon_User_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exigence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    JalonID = table.Column<int>(type: "int", nullable: true),
                    ExigenceType = table.Column<int>(type: "int", nullable: false),
                    TaskEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exigence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exigence_Jalon_JalonID",
                        column: x => x.JalonID,
                        principalTable: "Jalon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exigence_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exigence_Task_TaskEntityId",
                        column: x => x.TaskEntityId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, null, "Clem", "Laurain", null },
                    { 2, null, "Olivier", "Petrerella", null },
                    { 3, null, "Hugo", "Molle", null },
                    { 4, null, "Henri", "Michelon", null },
                    { 5, null, "Julien", "Drevron", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_JalonID",
                table: "Exigence",
                column: "JalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_ProjectId",
                table: "Exigence",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_TaskEntityId",
                table: "Exigence",
                column: "TaskEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jalon_AssigneeId",
                table: "Jalon",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jalon_ProjectId",
                table: "Jalon",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AssigneeId",
                table: "Project",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_AssigneeId",
                table: "Task",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_RequiredTaskId",
                table: "Task",
                column: "RequiredTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exigence");

            migrationBuilder.DropTable(
                name: "Jalon");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
