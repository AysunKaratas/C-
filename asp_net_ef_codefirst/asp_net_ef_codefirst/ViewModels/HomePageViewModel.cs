using asp_net_ef_codefirst.Context;
using asp_net_ef_codefirst.Context.Managers;
using asp_net_ef_codefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            KategoriAdiListeleListesi = new List<GorevVeKategoriAdiListele>();// constract .Modelden türetilmniş bir list olduğu için bunun türetilmesini ister
        }
        public List<Categori> Categoris { get; set; }
        public List<Gorev> Gorevs { get; set; }

        public List<GorevVeKategoriAdiListele> KategoriAdiListeleListesi { get; set; }

        public string TC { get; set; }

        public int GorevId { get; set; }
        public string KategoriAdi { get; set; }
        public string GorevAdi { get; set; } // Görev modelden değiştirdiklerimizi bu sayfaya hata vermemesi için ekliyoruz .Bir sayfada bir tane model olur.o yüzden homepage gibi ortak bir view model ekliyoruz listelemeleri çekebilmek için.
        public int KategoriId { get; set; }

        public List<Categori> Kategoriler { get; set; }
    }
}