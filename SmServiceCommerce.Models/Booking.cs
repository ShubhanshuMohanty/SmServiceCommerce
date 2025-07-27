using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; } = null!;

        public string ServiceProviderId { get; set; } = null!;
        [ForeignKey("ServiceProviderId")]
        public ApplicationUser ServiceProvider { get; set; } = null!;

        [Required]
        public DateOnly BookingDate { get; set; } 
        [Required]
        public TimeOnly BookingTime { get; set; } 

        [MaxLength(500)]
        public string? Notes { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // e.g. Pending, Confirmed, Cancelled
    }

}
