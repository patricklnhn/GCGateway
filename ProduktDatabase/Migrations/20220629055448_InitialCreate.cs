using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProduktDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forretningstjeneste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forretningstjeneste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Komponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tilvalg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilvalg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tjeneste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForretningstjenesteId = table.Column<int>(type: "int", nullable: false),
                    TjenesteNummer = table.Column<int>(type: "int", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersjonsNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tjeneste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tjeneste_Forretningstjeneste_ForretningstjenesteId",
                        column: x => x.ForretningstjenesteId,
                        principalTable: "Forretningstjeneste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KomponentKostnader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomponentId = table.Column<int>(type: "int", nullable: false),
                    FraDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomponentKostnader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KomponentKostnader_Komponent_KomponentId",
                        column: x => x.KomponentId,
                        principalTable: "Komponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TilvalgKostnader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TilvalgId = table.Column<int>(type: "int", nullable: false),
                    FraDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilvalgKostnader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TilvalgKostnader_Tilvalg_TilvalgId",
                        column: x => x.TilvalgId,
                        principalTable: "Tilvalg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TilvalgPrTjeneste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TjenesteId = table.Column<int>(type: "int", nullable: false),
                    TilvalgId = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilvalgPrTjeneste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TilvalgPrTjeneste_Tilvalg_TilvalgId",
                        column: x => x.TilvalgId,
                        principalTable: "Tilvalg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TilvalgPrTjeneste_Tjeneste_TjenesteId",
                        column: x => x.TjenesteId,
                        principalTable: "Tjeneste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TjenesteKomponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TjenesteId = table.Column<int>(type: "int", nullable: false),
                    KomponentId = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TjenesteKomponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TjenesteKomponent_Komponent_KomponentId",
                        column: x => x.KomponentId,
                        principalTable: "Komponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TjenesteKomponent_Tjeneste_TjenesteId",
                        column: x => x.TjenesteId,
                        principalTable: "Tjeneste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TjenesteKostnaderOgInntekter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TjenesteId = table.Column<int>(type: "int", nullable: false),
                    FraDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTR = table.Column<int>(type: "int", nullable: false),
                    MRR = table.Column<int>(type: "int", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TjenesteKostnaderOgInntekter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TjenesteKostnaderOgInntekter_Tjeneste_TjenesteId",
                        column: x => x.TjenesteId,
                        principalTable: "Tjeneste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KomponentKostnader_KomponentId",
                table: "KomponentKostnader",
                column: "KomponentId");

            migrationBuilder.CreateIndex(
                name: "IX_TilvalgKostnader_TilvalgId",
                table: "TilvalgKostnader",
                column: "TilvalgId");

            migrationBuilder.CreateIndex(
                name: "IX_TilvalgPrTjeneste_TilvalgId",
                table: "TilvalgPrTjeneste",
                column: "TilvalgId");

            migrationBuilder.CreateIndex(
                name: "IX_TilvalgPrTjeneste_TjenesteId",
                table: "TilvalgPrTjeneste",
                column: "TjenesteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tjeneste_ForretningstjenesteId",
                table: "Tjeneste",
                column: "ForretningstjenesteId");

            migrationBuilder.CreateIndex(
                name: "IX_TjenesteKomponent_KomponentId",
                table: "TjenesteKomponent",
                column: "KomponentId");

            migrationBuilder.CreateIndex(
                name: "IX_TjenesteKomponent_TjenesteId",
                table: "TjenesteKomponent",
                column: "TjenesteId");

            migrationBuilder.CreateIndex(
                name: "IX_TjenesteKostnaderOgInntekter_TjenesteId",
                table: "TjenesteKostnaderOgInntekter",
                column: "TjenesteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KomponentKostnader");

            migrationBuilder.DropTable(
                name: "TilvalgKostnader");

            migrationBuilder.DropTable(
                name: "TilvalgPrTjeneste");

            migrationBuilder.DropTable(
                name: "TjenesteKomponent");

            migrationBuilder.DropTable(
                name: "TjenesteKostnaderOgInntekter");

            migrationBuilder.DropTable(
                name: "Tilvalg");

            migrationBuilder.DropTable(
                name: "Komponent");

            migrationBuilder.DropTable(
                name: "Tjeneste");

            migrationBuilder.DropTable(
                name: "Forretningstjeneste");
        }
    }
}
