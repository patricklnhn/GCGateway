using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointDatabase.Migrations
{
    public partial class UpdatedDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fylkesnummer",
                table: "Fylke",
                newName: "FylkesNummer");

            migrationBuilder.RenameColumn(
                name: "Fylkesnavn",
                table: "Fylke",
                newName: "FylkesNavn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FylkesNummer",
                table: "Fylke",
                newName: "Fylkesnummer");

            migrationBuilder.RenameColumn(
                name: "FylkesNavn",
                table: "Fylke",
                newName: "Fylkesnavn");
        }
    }
}
