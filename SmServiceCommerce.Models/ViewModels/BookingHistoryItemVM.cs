using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models.ViewModels
{
    public class BookingHistoryItemVM
    {
        public Booking Booking { get; set; }
        public ServiceProviderInfo? serviceProviderInfo { get; set; }
    }
}
