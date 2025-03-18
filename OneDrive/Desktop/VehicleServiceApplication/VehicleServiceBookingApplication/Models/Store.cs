using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleServiceBookingApplication.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        [StringLength(100)]
        public string StoreName { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string State { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
