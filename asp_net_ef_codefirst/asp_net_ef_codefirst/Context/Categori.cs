using asp_net_ef_codefirst.Context.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Context
{
    [Table("Kategori")]
    public class Categori
    {   
        [Key ,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(150)]
        public string KategoriAdi { get; set; }
        
        public int KisiId { get; set; }

        public virtual Kisiler Kisi { get; set; }
        public virtual List<Gorev> Görevs { get; set; }
    }
}