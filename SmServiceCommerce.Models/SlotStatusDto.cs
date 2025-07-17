using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models
{
    public class SlotStatusDto
    {
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; } = "";
        public string Status { get; set; } = ""; // "Available" or "Booked"
    }

}
