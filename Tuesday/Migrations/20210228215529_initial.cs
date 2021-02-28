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
                name: "UtilisateurEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateurEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taskRepo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    asigneeId = table.Column<int>(type: "int", nullable: true),
                    plannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    realStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    requiredTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskRepo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskRepo_taskRepo_requiredTaskId",
                        column: x => x.requiredTaskId,
                        principalTable: "taskRepo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_taskRepo_UtilisateurEntity_asigneeId",
                        column: x => x.asigneeId,
                        principalTable: "UtilisateurEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taskRepo_asigneeId",
                table: "taskRepo",
                column: "asigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_taskRepo_requiredTaskId",
                table: "taskRepo",
                column: "requiredTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taskRepo");

            migrationBuilder.DropTable(
                name: "UtilisateurEntity");
        }
    }
}
