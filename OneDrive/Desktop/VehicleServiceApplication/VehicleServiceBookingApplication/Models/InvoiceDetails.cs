using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleServiceBookingApplication.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public int BookingId { get; set; }
        [Required]
        public DateTime CompletionDate{ get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public Decimal ServiceCharges { get; set; }
        [ForeignKey("BookingId")]
        public virtual ServiceBookings ServiceBookings { get; set; }
        
    }
}
