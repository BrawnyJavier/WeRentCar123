using Microsoft.EntityFrameworkCore.Migrations;

namespace WeRentCar123.Context.Migrations
{
    public partial class Upsreportview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DROP VIEW IF EXISTS DailyReport;
GO
CREATE VIEW DailyReport 
AS (
	SELECT CAST([VehicleRentalRegistrationDate] as DATE) as DATE
		   ,SUM([DailyRentalPrice]* DATEDIFF(day,CAST([RentFromDate] as DATE),CAST([RentToDate] as DATE))) INCOME,
		  COUNT(*) as CARS_RENTED
	FROM [WeRentCar123].[dbo].[VehicleRentals]
	GROUP BY CAST([VehicleRentalRegistrationDate] as DATE) 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS DailyReport;");
        }
    }
}
