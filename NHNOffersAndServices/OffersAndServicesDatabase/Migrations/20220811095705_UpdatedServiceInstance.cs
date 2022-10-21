using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffersAndServicesDatabase.Migrations
{
    public partial class UpdatedServiceInstance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "ServiceInstances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MercantileStatusId",
                table: "ServiceInstances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OfferValidToDate",
                table: "ServiceInstances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TechnicalStatusId",
                table: "ServiceInstances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "ServiceInstances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VersionNumber",
                table: "ServiceInstances",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInstances_MercantileStatusId",
                table: "ServiceInstances",
                column: "MercantileStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInstances_TechnicalStatusId",
                table: "ServiceInstances",
                column: "TechnicalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInstances_MercantileStatuses_MercantileStatusId",
                table: "ServiceInstances",
                column: "MercantileStatusId",
                principalTable: "MercantileStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInstances_TechnicalStatuses_TechnicalStatusId",
                table: "ServiceInstances",
                column: "TechnicalStatusId",
                principalTable: "TechnicalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInstances_MercantileStatuses_MercantileStatusId",
                table: "ServiceInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInstances_TechnicalStatuses_TechnicalStatusId",
                table: "ServiceInstances");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInstances_MercantileStatusId",
                table: "ServiceInstances");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInstances_TechnicalStatusId",
                table: "ServiceInstances");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "ServiceInstances");

            migrationBuilder.DropColumn(
                name: "MercantileStatusId",
                table: "ServiceInstances");

            migrationBuilder.DropColumn(
                name: "OfferValidToDate",
                table: "ServiceInstances");

            migrationBuilder.DropColumn(
                name: "TechnicalStatusId",
                table: "ServiceInstances");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "ServiceInstances");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "ServiceInstances");
        }
    }
}
