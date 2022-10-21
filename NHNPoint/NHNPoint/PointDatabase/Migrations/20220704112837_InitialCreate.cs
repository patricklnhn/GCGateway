using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FartøyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FartøyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelseRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelseRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokasjon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Orgnummer = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokasjon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fylke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fylkesnummer = table.Column<int>(type: "int", nullable: false),
                    Fylkesnavn = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HelseRegionId = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fylke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fylke_HelseRegion_HelseRegionId",
                        column: x => x.HelseRegionId,
                        principalTable: "HelseRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fartøy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LokasjonId = table.Column<int>(type: "int", nullable: false),
                    FartøyTypeId = table.Column<int>(type: "int", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Registreringsnummer = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fartøy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fartøy_FartøyType_FartøyTypeId",
                        column: x => x.FartøyTypeId,
                        principalTable: "FartøyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fartøy_Lokasjon_LokasjonId",
                        column: x => x.LokasjonId,
                        principalTable: "Lokasjon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kommune",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kommunenummer = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Kommunenavn = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FylkeId = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommune", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kommune_Fylke_FylkeId",
                        column: x => x.FylkeId,
                        principalTable: "Fylke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poststed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nummer = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    KommuneId = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poststed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poststed_Kommune_KommuneId",
                        column: x => x.KommuneId,
                        principalTable: "Kommune",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adressenavn = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Adressetilleggsnavn = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    PoststedId = table.Column<int>(type: "int", nullable: false),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    GNR = table.Column<int>(type: "int", nullable: false),
                    BNR = table.Column<int>(type: "int", nullable: false),
                    Undernummer = table.Column<int>(type: "int", nullable: true),
                    Bruksenhetsnummer = table.Column<int>(type: "int", nullable: true),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresse_Poststed_PoststedId",
                        column: x => x.PoststedId,
                        principalTable: "Poststed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bygning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseId = table.Column<int>(type: "int", nullable: false),
                    LokasjonId = table.Column<int>(type: "int", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    EPSG = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bygning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bygning_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bygning_Lokasjon_LokasjonId",
                        column: x => x.LokasjonId,
                        principalTable: "Lokasjon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BygningId = table.Column<int>(type: "int", nullable: false),
                    Etasje = table.Column<int>(type: "int", nullable: false),
                    Romnummer = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    KontaktPersonID = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rom_Bygning_BygningId",
                        column: x => x.BygningId,
                        principalTable: "Bygning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punkt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    RomId = table.Column<int>(type: "int", nullable: true),
                    BygningId = table.Column<int>(type: "int", nullable: true),
                    FartøyId = table.Column<int>(type: "int", nullable: true),
                    Bruker = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punkt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punkt_Bygning_BygningId",
                        column: x => x.BygningId,
                        principalTable: "Bygning",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Punkt_Fartøy_FartøyId",
                        column: x => x.FartøyId,
                        principalTable: "Fartøy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Punkt_Rom_RomId",
                        column: x => x.RomId,
                        principalTable: "Rom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_PoststedId",
                table: "Adresse",
                column: "PoststedId");

            migrationBuilder.CreateIndex(
                name: "IX_Bygning_AdresseId",
                table: "Bygning",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bygning_LokasjonId",
                table: "Bygning",
                column: "LokasjonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fartøy_FartøyTypeId",
                table: "Fartøy",
                column: "FartøyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fartøy_LokasjonId",
                table: "Fartøy",
                column: "LokasjonId");

            migrationBuilder.CreateIndex(
                name: "IX_Fartøy_Registreringsnummer",
                table: "Fartøy",
                column: "Registreringsnummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fylke_HelseRegionId",
                table: "Fylke",
                column: "HelseRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommune_FylkeId",
                table: "Kommune",
                column: "FylkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokasjon_Orgnummer",
                table: "Lokasjon",
                column: "Orgnummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poststed_KommuneId",
                table: "Poststed",
                column: "KommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Punkt_BygningId",
                table: "Punkt",
                column: "BygningId");

            migrationBuilder.CreateIndex(
                name: "IX_Punkt_FartøyId",
                table: "Punkt",
                column: "FartøyId");

            migrationBuilder.CreateIndex(
                name: "IX_Punkt_RomId",
                table: "Punkt",
                column: "RomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rom_BygningId",
                table: "Rom",
                column: "BygningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punkt");

            migrationBuilder.DropTable(
                name: "Fartøy");

            migrationBuilder.DropTable(
                name: "Rom");

            migrationBuilder.DropTable(
                name: "FartøyType");

            migrationBuilder.DropTable(
                name: "Bygning");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Lokasjon");

            migrationBuilder.DropTable(
                name: "Poststed");

            migrationBuilder.DropTable(
                name: "Kommune");

            migrationBuilder.DropTable(
                name: "Fylke");

            migrationBuilder.DropTable(
                name: "HelseRegion");
        }
    }
}
