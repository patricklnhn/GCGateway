using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointDatabase.Migrations
{
    public partial class UpdatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Addresses_AdressId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Buildings_BygningId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Rooms_RomId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Vehicles_FartøyId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BygningId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Locations_LokasjonId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_FartøyTypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Orgnummer",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Navn",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Navn",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "Poststed");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Navn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Orgnummer",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "Kommune");

            migrationBuilder.DropColumn(
                name: "Bruker",
                table: "HealthRegions");

            migrationBuilder.DropColumn(
                name: "Kode",
                table: "HealthRegions");

            migrationBuilder.RenameColumn(
                name: "Registreringsnummer",
                table: "Vehicles",
                newName: "Registration");

            migrationBuilder.RenameColumn(
                name: "LokasjonId",
                table: "Vehicles",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "FartøyTypeId",
                table: "Vehicles",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_Registreringsnummer",
                table: "Vehicles",
                newName: "IX_Vehicles_Registration");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_LokasjonId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_FartøyTypeId",
                table: "Vehicles",
                newName: "IX_Vehicles_LocationId");

            migrationBuilder.RenameColumn(
                name: "Romnummer",
                table: "Rooms",
                newName: "RoomNumber");

            migrationBuilder.RenameColumn(
                name: "KontaktPersonID",
                table: "Rooms",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "Etasje",
                table: "Rooms",
                newName: "ContactPersonID");

            migrationBuilder.RenameColumn(
                name: "BygningId",
                table: "Rooms",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BygningId",
                table: "Rooms",
                newName: "IX_Rooms_BuildingId");

            migrationBuilder.RenameColumn(
                name: "Nummer",
                table: "Poststed",
                newName: "PostNummer");

            migrationBuilder.RenameColumn(
                name: "RomId",
                table: "Points",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "FartøyId",
                table: "Points",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "BygningId",
                table: "Points",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_RomId",
                table: "Points",
                newName: "IX_Points_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_FartøyId",
                table: "Points",
                newName: "IX_Points_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_BygningId",
                table: "Points",
                newName: "IX_Points_BuildingId");

            migrationBuilder.RenameColumn(
                name: "Navn",
                table: "HealthRegions",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Buildings",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_AdressId",
                table: "Buildings",
                newName: "IX_Buildings_AddressId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VehicleTypes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "VehicleTypes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Vehicles",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Rooms",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Poststed",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Points",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Points",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrgNumber",
                table: "Locations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Locations",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kommunenummer",
                table: "Kommune",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Kommunenavn",
                table: "Kommune",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Kommune",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HealthRegions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "HealthRegions",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Buildings",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EPSG",
                table: "Buildings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Addresses",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OrgNumber",
                table: "Locations",
                column: "OrgNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Addresses_AddressId",
                table: "Buildings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Buildings_BuildingId",
                table: "Points",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Rooms_RoomId",
                table: "Points",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Vehicles_VehicleId",
                table: "Points",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Locations_LocationId",
                table: "Vehicles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Addresses_AddressId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Buildings_BuildingId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Rooms_RoomId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Vehicles_VehicleId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Locations_LocationId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Locations_OrgNumber",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "User",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Poststed");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "OrgNumber",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Kommune");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HealthRegions");

            migrationBuilder.DropColumn(
                name: "User",
                table: "HealthRegions");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "Vehicles",
                newName: "LokasjonId");

            migrationBuilder.RenameColumn(
                name: "Registration",
                table: "Vehicles",
                newName: "Registreringsnummer");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Vehicles",
                newName: "FartøyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                newName: "IX_Vehicles_LokasjonId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_Registration",
                table: "Vehicles",
                newName: "IX_Vehicles_Registreringsnummer");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_LocationId",
                table: "Vehicles",
                newName: "IX_Vehicles_FartøyTypeId");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Rooms",
                newName: "Romnummer");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Rooms",
                newName: "KontaktPersonID");

            migrationBuilder.RenameColumn(
                name: "ContactPersonID",
                table: "Rooms",
                newName: "Etasje");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Rooms",
                newName: "BygningId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                newName: "IX_Rooms_BygningId");

            migrationBuilder.RenameColumn(
                name: "PostNummer",
                table: "Poststed",
                newName: "Nummer");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Points",
                newName: "RomId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Points",
                newName: "FartøyId");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Points",
                newName: "BygningId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_VehicleId",
                table: "Points",
                newName: "IX_Points_RomId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_RoomId",
                table: "Points",
                newName: "IX_Points_FartøyId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_BuildingId",
                table: "Points",
                newName: "IX_Points_BygningId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "HealthRegions",
                newName: "Navn");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Buildings",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_AddressId",
                table: "Buildings",
                newName: "IX_Buildings_AdressId");

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Navn",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Navn",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "Poststed",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "Points",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Navn",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Orgnummer",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kommunenummer",
                table: "Kommune",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Kommunenavn",
                table: "Kommune",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "Kommune",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bruker",
                table: "HealthRegions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kode",
                table: "HealthRegions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "EPSG",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Orgnummer",
                table: "Locations",
                column: "Orgnummer",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Addresses_AdressId",
                table: "Buildings",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Buildings_BygningId",
                table: "Points",
                column: "BygningId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Rooms_RomId",
                table: "Points",
                column: "RomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Vehicles_FartøyId",
                table: "Points",
                column: "FartøyId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BygningId",
                table: "Rooms",
                column: "BygningId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Locations_LokasjonId",
                table: "Vehicles",
                column: "LokasjonId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_FartøyTypeId",
                table: "Vehicles",
                column: "FartøyTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
