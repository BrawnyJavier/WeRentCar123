using System;

namespace WeRentCar123.Models
{
    public class VehicleRental
    {
        public int VehicleRentalID { get; set; }
        public DateTime VehicleRentalRegistrationDate { get; set; }
        public VehicleRentalClient VehicleRentalClient { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime RentFromDate { get; set; }
        public DateTime RentToDate { get; set; }
        public decimal DailyRentalPrice { get; set; }
        public string  Notes { get; set; }
    }
}
