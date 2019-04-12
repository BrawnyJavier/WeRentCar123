using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeRentCar123.Models
{
    public class VehicleModel
    {
        [Key]
        public int VehicleModelID { get; set; }
        [StringLength(100)]
        [DisplayName("Model Name")]
        public string VehicleModelName { get; set; }
        [StringLength(600)]
        [DisplayName("Description")]
        public string VehicleModelDescription { get; set; }
        [DisplayName("Brand")]
        public VehicleBrand VehicleBrand { get; set; }
        [ForeignKey("VehicleBrand")]
        public int VehicleBrandID { get; set; }
        [DisplayName("Model Year")]
        public int VehicleModelYear { get; set; }
        [DisplayName("Recommended Rental Daily Price")]
        public decimal RecommendedRentalDailyPrice { get; set; }
    }
}
