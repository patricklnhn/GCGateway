using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalConnectDataDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GcCoverageCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GcGabId = table.Column<int>(type: "int", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GcCoverageCheck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Junta2GcConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuntaId = table.Column<int>(type: "int", nullable: false),
                    GcGabId = table.Column<int>(type: "int", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junta2GcConnections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GcCoverageCheck");

            migrationBuilder.DropTable(
                name: "Junta2GcConnections");
        }
    }
}
