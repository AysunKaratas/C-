using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Models
{
    public class KayitOlModel
    {
      
        [Required]
        [StringLength(12,MinimumLength =11,ErrorMessage ="11 karakter olmalıdır")]
        public string TC { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "11 karakter olmalıdır")]
        public string Telephone { get; set; }
    }
}