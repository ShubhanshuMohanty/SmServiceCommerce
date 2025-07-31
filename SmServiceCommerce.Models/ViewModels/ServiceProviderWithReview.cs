using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models.ViewModels
{
    public class ServiceProviderWithReview
    {
        public ServiceProviderInfo serviceProviderInfo { get; set; }
        public List<Review> reviews { get; set; }=new List<Review>();
        public string Comment { get; set; }
        public int Rating { get; set; } = 1;
        public float AvgRating { get; set; }
        public int TotalReview { get; set; }
    }
}
