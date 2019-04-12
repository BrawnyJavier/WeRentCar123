using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeRentCar123.Models
{
    public class Vehicle
    {
        [DisplayName("Vehicle Code")]
        public int VehicleID { get; set; }
        public VehicleModel VehicleModel { get; set; }
        [ForeignKey("VehicleModel")]
        public int VehicleModelID { get; set; }
        [DisplayName("Notes")]
        public string VehicleNotes { get; set; }
        public string Color { get; set; }
    }
}
