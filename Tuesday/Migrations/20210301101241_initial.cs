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
                name: "Utilisateur",
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
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jalon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: true),
                    ProjetEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jalon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jalon_Projet_ProjetEntityId",
                        column: x => x.ProjetEntityId,
                        principalTable: "Projet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jalon_Utilisateur_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tache",
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

            migrationBuilder.CreateTable(
                name: "Exigence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    JalonId = table.Column<int>(type: "int", nullable: true),
                    ExigenceType = table.Column<int>(type: "int", nullable: false),
                    TacheEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exigence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exigence_Jalon_JalonId",
                        column: x => x.JalonId,
                        principalTable: "Jalon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exigence_Tache_TacheEntityId",
                        column: x => x.TacheEntityId,
                        principalTable: "Tache",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_JalonId",
                table: "Exigence",
                column: "JalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Exigence_TacheEntityId",
                table: "Exigence",
                column: "TacheEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jalon_AssigneeId",
                table: "Jalon",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jalon_ProjetEntityId",
                table: "Jalon",
                column: "ProjetEntityId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exigence");

            migrationBuilder.DropTable(
                name: "Tache");

            migrationBuilder.DropTable(
                name: "Jalon");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
