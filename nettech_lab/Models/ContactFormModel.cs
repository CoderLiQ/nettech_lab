using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nettech_lab.Models
{
    public class ContactFormModel {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(2000)]
        [Required]
        public string Message { get; set; }
    }
}
