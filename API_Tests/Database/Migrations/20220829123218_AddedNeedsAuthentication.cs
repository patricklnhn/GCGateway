using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class AddedNeedsAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APIParameters_ExternalAPs_ExternalAPIId",
                table: "APIParameters");

            migrationBuilder.DropIndex(
                name: "IX_APIParameters_ExternalAPIId",
                table: "APIParameters");

            migrationBuilder.DropColumn(
                name: "ExternalAPIId",
                table: "APIParameters");

            migrationBuilder.AddColumn<bool>(
                name: "NeedsAuthentication",
                table: "ExternalAPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "APIParameters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_APIParameters_ExternalAPs_Id",
                table: "APIParameters",
                column: "Id",
                principalTable: "ExternalAPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APIParameters_ExternalAPs_Id",
                table: "APIParameters");

            migrationBuilder.DropColumn(
                name: "NeedsAuthentication",
                table: "ExternalAPs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "APIParameters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ExternalAPIId",
                table: "APIParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_APIParameters_ExternalAPIId",
                table: "APIParameters",
                column: "ExternalAPIId");

            migrationBuilder.AddForeignKey(
                name: "FK_APIParameters_ExternalAPs_ExternalAPIId",
                table: "APIParameters",
                column: "ExternalAPIId",
                principalTable: "ExternalAPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
