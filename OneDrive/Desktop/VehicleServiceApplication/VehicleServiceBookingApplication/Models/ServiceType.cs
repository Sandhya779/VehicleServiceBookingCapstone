using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleServiceBookingApplication.Models
{
    public class ServiceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string ServiceTypeName { get; set; }
    }
}
