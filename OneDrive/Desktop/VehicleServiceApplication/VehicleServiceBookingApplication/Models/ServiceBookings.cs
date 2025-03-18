using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleServiceBookingApplication.Models
{
    public class ServiceBookings
    {
        [Key]
        public int BookingId { get; set; }
        
        [Required]
        public int StoreId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string VehicleDetails { get; set; }

        [Required]
        public int ServiceTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string ServicesBooked { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int StatusId { get; set; } = 1;

        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }



    }
}
