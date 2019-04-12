using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeRentCar123.Models
{
    public class VehicleRental
    {
        [Key]
        [DisplayName("Rent code")]
        public int VehicleRentalID { get; set; }
        [DisplayName("Registration Date")]
        public DateTime VehicleRentalRegistrationDate { get; set; }
        [DisplayName("Client Code")]
        public int VehicleRentalClientId { get; set; }
        [ForeignKey("VehicleRentalClientId")]
        [DisplayName("Client")]
        public VehicleRentalClient VehicleRentalClient { get; set; }
        [DisplayName("Vehicle code")]
        public int VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }
        [DisplayName("From Date")]
        public DateTime RentFromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime RentToDate { get; set; }
        [DisplayName("Daily Rental Price")]
        public decimal DailyRentalPrice { get; set; }
        public string  Notes { get; set; }
    }
}
