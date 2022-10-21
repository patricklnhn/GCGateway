using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffersAndServicesDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentInstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MercantileStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    User = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercantileStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinesServiceID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RegisteredBy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionValues_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceNumber = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    OrgNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceLocation = table.Column<int>(type: "int", nullable: false),
                    RedundantServiceLocation = table.Column<int>(type: "int", nullable: false),
                    ServiceContactId = table.Column<int>(type: "int", nullable: false),
                    ServiceContactName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    User = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInstances_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionsChosen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceInstanceId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    OptionValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsChosen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsChosen_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OptionsChosen_OptionValues_OptionValueId",
                        column: x => x.OptionValueId,
                        principalTable: "OptionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OptionsChosen_ServiceInstances_ServiceInstanceId",
                        column: x => x.ServiceInstanceId,
                        principalTable: "ServiceInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInstancesCostAndIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceInstanceId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTR = table.Column<int>(type: "int", nullable: false),
                    MRR = table.Column<int>(type: "int", nullable: false),
                    OTC = table.Column<int>(type: "int", nullable: false),
                    MRC = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TS = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInstancesCostAndIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInstancesCostAndIncome_ServiceInstances_ServiceInstanceId",
                        column: x => x.ServiceInstanceId,
                        principalTable: "ServiceInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionsChosen_OptionId",
                table: "OptionsChosen",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsChosen_OptionValueId",
                table: "OptionsChosen",
                column: "OptionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsChosen_ServiceInstanceId",
                table: "OptionsChosen",
                column: "ServiceInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionValues_OptionId",
                table: "OptionValues",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInstances_RequestId",
                table: "ServiceInstances",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInstancesCostAndIncome_ServiceInstanceId",
                table: "ServiceInstancesCostAndIncome",
                column: "ServiceInstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentInstances");

            migrationBuilder.DropTable(
                name: "MercantileStatuses");

            migrationBuilder.DropTable(
                name: "OptionsChosen");

            migrationBuilder.DropTable(
                name: "ServiceInstancesCostAndIncome");

            migrationBuilder.DropTable(
                name: "TechnicalStatuses");

            migrationBuilder.DropTable(
                name: "OptionValues");

            migrationBuilder.DropTable(
                name: "ServiceInstances");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
