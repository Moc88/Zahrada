using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OsevniPlan.Data.Migrations
{
    public partial class Tabulkyrokyplodiny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plodina",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Odruda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vyrobce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oseto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plodina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rok",
                columns: table => new
                {
                    Id = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rok", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plodina");

            migrationBuilder.DropTable(
                name: "Rok");
        }
    }
}
