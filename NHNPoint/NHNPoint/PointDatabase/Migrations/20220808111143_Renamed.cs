using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointDatabase.Migrations
{
    public partial class Renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fylke_HelseRegion_HelseRegionId",
                table: "Fylke");

            migrationBuilder.DropTable(
                name: "HelseRegion");

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

            migrationBuilder.RenameColumn(
                name: "Aktiv",
                table: "Poststed",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Aktiv",
                table: "Kommune",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Bruker",
                table: "Fylke",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Aktiv",
                table: "Fylke",
                newName: "Active");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adressenavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adressetilleggsnavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoststedId = table.Column<int>(type: "int", nullable: false),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    GNR = table.Column<int>(type: "int", nullable: false),
                    BNR = table.Column<int>(type: "int", nullable: false),
                    Undernummer = table.Column<int>(type: "int", nullable: true),
                    Bruksenhetsnummer = table.Column<int>(type: "int", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Poststed_PoststedId",
                        column: x => x.PoststedId,
                        principalTable: "Poststed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthRegions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orgnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    EPSG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Addresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buildings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LokasjonId = table.Column<int>(type: "int", nullable: false),
                    FartøyTypeId = table.Column<int>(type: "int", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registreringsnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Locations_LokasjonId",
                        column: x => x.LokasjonId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_FartøyTypeId",
                        column: x => x.FartøyTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BygningId = table.Column<int>(type: "int", nullable: false),
                    Etasje = table.Column<int>(type: "int", nullable: false),
                    Romnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktPersonID = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BygningId",
                        column: x => x.BygningId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RomId = table.Column<int>(type: "int", nullable: true),
                    BygningId = table.Column<int>(type: "int", nullable: true),
                    FartøyId = table.Column<int>(type: "int", nullable: true),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Buildings_BygningId",
                        column: x => x.BygningId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Points_Rooms_RomId",
                        column: x => x.RomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Points_Vehicles_FartøyId",
                        column: x => x.FartøyId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PoststedId",
                table: "Addresses",
                column: "PoststedId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AdressId",
                table: "Buildings",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LocationId",
                table: "Buildings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Orgnummer",
                table: "Locations",
                column: "Orgnummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Points_BygningId",
                table: "Points",
                column: "BygningId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_FartøyId",
                table: "Points",
                column: "FartøyId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_RomId",
                table: "Points",
                column: "RomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BygningId",
                table: "Rooms",
                column: "BygningId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FartøyTypeId",
                table: "Vehicles",
                column: "FartøyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LokasjonId",
                table: "Vehicles",
                column: "LokasjonId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Registreringsnummer",
                table: "Vehicles",
                column: "Registreringsnummer",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fylke_HealthRegions_HelseRegionId",
                table: "Fylke",
                column: "HelseRegionId",
                principalTable: "HealthRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fylke_HealthRegions_HelseRegionId",
                table: "Fylke");

            migrationBuilder.DropTable(
                name: "HealthRegions");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Poststed",
                newName: "Aktiv");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Kommune",
                newName: "Aktiv");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Fylke",
                newName: "Bruker");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Fylke",
                newName: "Aktiv");

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoststedId = table.Column<int>(type: "int", nullable: false),
                    Adressenavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adressetilleggsnavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BNR = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bruksenhetsnummer = table.Column<int>(type: "int", nullable: true),
                    GNR = table.Column<int>(type: "int", nullable: false),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Undernummer = table.Column<int>(type: "int", nullable: true)
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
                name: "FartøyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<int>(type: "int", nullable: false),
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
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orgnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokasjon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bygning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseId = table.Column<int>(type: "int", nullable: false),
                    LokasjonId = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPSG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: false),
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
                name: "Fartøy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FartøyTypeId = table.Column<int>(type: "int", nullable: false),
                    LokasjonId = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registreringsnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Rom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BygningId = table.Column<int>(type: "int", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etasje = table.Column<int>(type: "int", nullable: false),
                    KontaktPersonID = table.Column<int>(type: "int", nullable: false),
                    Romnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    BygningId = table.Column<int>(type: "int", nullable: true),
                    FartøyId = table.Column<int>(type: "int", nullable: true),
                    RomId = table.Column<int>(type: "int", nullable: true),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_Lokasjon_Orgnummer",
                table: "Lokasjon",
                column: "Orgnummer",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Fylke_HelseRegion_HelseRegionId",
                table: "Fylke",
                column: "HelseRegionId",
                principalTable: "HelseRegion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
