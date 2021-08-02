using asp_net_ef_codefirst.Context;
using asp_net_ef_codefirst.Context.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Models
{
    public class GorevModel
    {
      
        public string GorevAdi { get; set; }
        public int KategoriId { get; set; }

        public int GuncellenecekGorevId { get; set; }

        public List<Categori> Kategoriler { get; set; }
        public List<Gorev> gorevler { get; set; }
    }
}