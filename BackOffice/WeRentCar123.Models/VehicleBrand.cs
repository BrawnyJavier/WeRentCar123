using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;

namespace WeRentCar123.Models
{
    public class VehicleBrand
    {
        [Key]
        public int VehicleBrandID { get; set; }
        [StringLength(100),DisplayName("Brand name")]
        public string VehicleBrandName { get; set; }
        [StringLength(600),DisplayName("Brand Description")]
        public string VehicleBrandDescription { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
        [DisplayName("Introduction date")]
        public DateTime VehicleBrandIntroductionDate { get; set; }
    }
}
