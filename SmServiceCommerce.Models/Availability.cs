using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }

        public string ServiceProviderId { get; set; } = null!;
        [ForeignKey("ServiceProviderId")]
        public ApplicationUser ServiceProvider { get; set; } = null!;

        [Required]
        public DayOfWeek Day { get; set; } // e.g. Monday, Tuesday

        [Required]
        public TimeSpan StartTime { get; set; } // e.g. 10:00 AM

        [Required]
        public TimeSpan EndTime { get; set; } // e.g. 6:00 PM
    }

}
