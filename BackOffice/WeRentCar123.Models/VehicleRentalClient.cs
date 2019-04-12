using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeRentCar123.Models
{
    public class VehicleRentalClient
    {
        [Key]
        [DisplayName("Client Code")]
        public int VehicleRentalClientId { get; set; }
        [StringLength(100)]
        [DisplayName("Client Names")]
        public string Name { get; set; }
        [StringLength(100)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        [StringLength(100)]
        public string ID { get; set; }
        public string Address { get; set; }
    }
}
