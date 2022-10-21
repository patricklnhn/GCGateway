using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffersAndServicesDatabase.Migrations
{
    public partial class UpdateedColSAndAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrgNumber",
                table: "ServiceInstances",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "ComponentInstances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceInstanceId",
                table: "ComponentInstances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentInstances_ServiceInstanceId",
                table: "ComponentInstances",
                column: "ServiceInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentInstances_ServiceInstances_ServiceInstanceId",
                table: "ComponentInstances",
                column: "ServiceInstanceId",
                principalTable: "ServiceInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentInstances_ServiceInstances_ServiceInstanceId",
                table: "ComponentInstances");

            migrationBuilder.DropIndex(
                name: "IX_ComponentInstances_ServiceInstanceId",
                table: "ComponentInstances");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "ComponentInstances");

            migrationBuilder.DropColumn(
                name: "ServiceInstanceId",
                table: "ComponentInstances");

            migrationBuilder.AlterColumn<string>(
                name: "OrgNumber",
                table: "ServiceInstances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
