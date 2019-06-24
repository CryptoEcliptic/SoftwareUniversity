using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.App.Models.Package
{
    public class PackageCreateBindingModel
    {
       
        [Required]
        [MinLength(5, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string Recipient { get; set; }
    }
}
