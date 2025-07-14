using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.Models
{
    public class Service
    {
        [Key]        
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Service Name")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Service name can only contain letters, numbers, and spaces.")]
        public string ServiceName { get; set; }
        
    }
}
