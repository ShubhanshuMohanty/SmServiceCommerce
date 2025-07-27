using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models
{
    public class ServiceProviderInfo
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; } = null!;

        public float Experience { get; set; }
        public string? Description { get; set; }
        public int ServiceFee { get; set; }

    }

}
