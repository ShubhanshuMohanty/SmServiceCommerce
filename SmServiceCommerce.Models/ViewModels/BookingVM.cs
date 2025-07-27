using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models.ViewModels
{
    public class BookingVM
    {
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string Notes { get; set; }
        public string ServiceProviderId { get; set; }
    }
}
