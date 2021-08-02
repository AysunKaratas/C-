using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Context
{

    [Table("Kisiler")]
    public class Kisiler
    { 
       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20),Required] // Boş geçilemez anlamına gelir
        public string TC { get; set; }
        [StringLength(50), Required]
        public string Sifre { get; set; }
        [StringLength(50), Required]
        public string Telefon { get; set; }
        public virtual List<Categori> Categoris { get; set; }
    }
}