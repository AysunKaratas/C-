using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Context.Managers
{
    [Table("Görev")]
    public class Gorev
    {
        public int Id { get; set; }
        public string GorevAdi { get; set; }

        public int KategoriId { get; set; }

        public int KisiId { get; set; }
        public virtual Categori Kategori { get; set; }

    }
}