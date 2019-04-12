using Microsoft.EntityFrameworkCore.Migrations;

namespace WeRentCar123.Context.Migrations
{
    public partial class addsnavpropertiestoVehicleRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRentals_Vehicles_VehicleID",
                table: "VehicleRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRentals_VehicleRentalClients_VehicleRentalClientId",
                table: "VehicleRentals");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleRentalClientId",
                table: "VehicleRentals",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleID",
                table: "VehicleRentals",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRentals_Vehicles_VehicleID",
                table: "VehicleRentals",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRentals_VehicleRentalClients_VehicleRentalClientId",
                table: "VehicleRentals",
                column: "VehicleRentalClientId",
                principalTable: "VehicleRentalClients",
                principalColumn: "VehicleRentalClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRentals_Vehicles_VehicleID",
                table: "VehicleRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRentals_VehicleRentalClients_VehicleRentalClientId",
                table: "VehicleRentals");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleRentalClientId",
                table: "VehicleRentals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "VehicleID",
                table: "VehicleRentals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRentals_Vehicles_VehicleID",
                table: "VehicleRentals",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRentals_VehicleRentalClients_VehicleRentalClientId",
                table: "VehicleRentals",
                column: "VehicleRentalClientId",
                principalTable: "VehicleRentalClients",
                principalColumn: "VehicleRentalClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
