using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProduktDatabase.Migrations
{
    public partial class renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BusinesServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinesServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinesServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_BusinesServices_BusinesServiceId",
                        column: x => x.BusinesServiceId,
                        principalTable: "BusinesServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentCosts_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionsCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsCosts_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionsPerServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsPerServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsPerServices_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionsPerServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesComponents_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesComponents_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesCostAndIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTR = table.Column<int>(type: "int", nullable: false),
                    MRR = table.Column<int>(type: "int", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesCostAndIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesCostAndIncome_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentCosts_ComponentId",
                table: "ComponentCosts",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsCosts_OptionId",
                table: "OptionsCosts",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsPerServices_OptionId",
                table: "OptionsPerServices",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsPerServices_ServiceId",
                table: "OptionsPerServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinesServiceId",
                table: "Services",
                column: "BusinesServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesComponents_ComponentId",
                table: "ServicesComponents",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesComponents_ServiceId",
                table: "ServicesComponents",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesCostAndIncome_ServiceId",
                table: "ServicesCostAndIncome",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentCosts");

            migrationBuilder.DropTable(
                name: "OptionsCosts");

            migrationBuilder.DropTable(
                name: "OptionsPerServices");

            migrationBuilder.DropTable(
                name: "ServicesComponents");

            migrationBuilder.DropTable(
                name: "ServicesCostAndIncome");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "BusinesServices");

            migrationBuilder.CreateTable(
                name: "Forretningstjeneste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TjenesteNummer = table.Column<int>(type: "int", nullable: false),
                    VersjonsNummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
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
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
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
                    TilvalgId = table.Column<int>(type: "int", nullable: false),
                    TjenesteId = table.Column<int>(type: "int", nullable: false),
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
                    KomponentId = table.Column<int>(type: "int", nullable: false),
                    TjenesteId = table.Column<int>(type: "int", nullable: false),
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
                    Bruker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    MRR = table.Column<int>(type: "int", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    OTR = table.Column<int>(type: "int", nullable: false),
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
    }
}
