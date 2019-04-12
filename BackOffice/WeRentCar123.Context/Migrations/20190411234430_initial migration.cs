using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeRentCar123.Context.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    VehicleBrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleBrandName = table.Column<string>(maxLength: 100, nullable: true),
                    VehicleBrandDescription = table.Column<string>(maxLength: 600, nullable: true),
                    VehicleBrandIntroductionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.VehicleBrandID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRentalClients",
                columns: table => new
                {
                    VehicleRentalClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRentalClients", x => x.VehicleRentalClientId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    VehicleModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleModelName = table.Column<string>(maxLength: 100, nullable: true),
                    VehicleModelDescription = table.Column<string>(maxLength: 600, nullable: true),
                    VehicleBrandID = table.Column<int>(nullable: false),
                    VehicleModelYear = table.Column<int>(nullable: false),
                    RecommendedRentalDailyPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.VehicleModelID);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_VehicleBrandID",
                        column: x => x.VehicleBrandID,
                        principalTable: "VehicleBrands",
                        principalColumn: "VehicleBrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleModelID = table.Column<int>(nullable: false),
                    VehicleNotes = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelID",
                        column: x => x.VehicleModelID,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRentals",
                columns: table => new
                {
                    VehicleRentalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleRentalRegistrationDate = table.Column<DateTime>(nullable: false),
                    VehicleRentalClientId = table.Column<int>(nullable: true),
                    VehicleID = table.Column<int>(nullable: true),
                    RentFromDate = table.Column<DateTime>(nullable: false),
                    RentToDate = table.Column<DateTime>(nullable: false),
                    DailyRentalPrice = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRentals", x => x.VehicleRentalID);
                    table.ForeignKey(
                        name: "FK_VehicleRentals_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleRentals_VehicleRentalClients_VehicleRentalClientId",
                        column: x => x.VehicleRentalClientId,
                        principalTable: "VehicleRentalClients",
                        principalColumn: "VehicleRentalClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandID",
                table: "VehicleModels",
                column: "VehicleBrandID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRentals_VehicleID",
                table: "VehicleRentals",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRentals_VehicleRentalClientId",
                table: "VehicleRentals",
                column: "VehicleRentalClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelID",
                table: "Vehicles",
                column: "VehicleModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleRentals");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleRentalClients");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
