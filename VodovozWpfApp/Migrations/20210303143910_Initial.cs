using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VodovozWpfApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.UniqueConstraint("AK_Orders_Number", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ManagerId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    FatherName = table.Column<string>(type: "TEXT", nullable: true),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sex = table.Column<int>(type: "INTEGER", nullable: false),
                    SubdivisionId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubdivisionId",
                table: "Employees",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AuthorId",
                table: "Orders",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivisions_ManagerId",
                table: "Subdivisions",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_AuthorId",
                table: "Orders",
                column: "AuthorId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subdivisions_Employees_ManagerId",
                table: "Subdivisions",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Subdivisions_SubdivisionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Subdivisions");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
