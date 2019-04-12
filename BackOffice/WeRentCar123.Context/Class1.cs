//< !--AUTHOR: Brawny Javier Mateo Reyes-- >
using Microsoft.EntityFrameworkCore;
using WeRentCar123.Models;
namespace WeRentCar123.Context
{
    public class WeRentCar123Context : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleRentalClient> VehicleRentalClients { get; set; }
        public DbSet<VehicleRental> VehicleRentals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=JAVIER-LAPTOP\\SQL_17;Initial Catalog=WeRentCar123;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }

}
