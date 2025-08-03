using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models.ViewModels
{
    public class SearchServiceProviderVM
    {
        public List<ServiceProviderVM> ServiceProviders { get; set; } = new List<ServiceProviderVM>();
    }
}
