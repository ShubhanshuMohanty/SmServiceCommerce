using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models.ViewModels
{
    public class BookingHistoryVM
    {
        public List<BookingHistoryItemVM> Items { get; set; } = new();
        public int totalBookingNumber { get; set; }
        public int totalConfirmBookingNumber { get; set; }
        public int totalPendingBookingNumber { get; set; }
        public int totalCompleteBookingNumber { get; set; }
        public int totalCancelBookingNumber { get; set; }
    }
}
