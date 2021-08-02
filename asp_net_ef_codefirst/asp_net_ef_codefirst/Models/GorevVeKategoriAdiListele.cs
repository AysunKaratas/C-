using asp_net_ef_codefirst.Context.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Models
{
    public class GorevVeKategoriAdiListele
    {
        public Gorev Gorevler { get; set; }

        public string KategoriAdi { get; set; }

    }
}