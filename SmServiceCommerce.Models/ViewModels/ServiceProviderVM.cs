using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models.ViewModels
{
    public class ServiceProviderVM
    {
        public ApplicationUser User { get; set; } = null!;
        public ServiceProviderInfo ServiceProviderInfo { get; set; } = null!;
    }
}
