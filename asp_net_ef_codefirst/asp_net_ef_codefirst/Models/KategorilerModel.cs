using asp_net_ef_codefirst.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Models
{
    public class KategorilerModel
    {
        public string KategoriAdi { get; set; }
        public List<Categori> kategoriler { get; set; }
    }
}