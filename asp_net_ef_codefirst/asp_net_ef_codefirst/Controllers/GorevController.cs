using asp_net_ef_codefirst.Context;
using asp_net_ef_codefirst.Context.Managers;
using asp_net_ef_codefirst.Models;
using asp_net_ef_codefirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_net_ef_codefirst.Controllers
{
    public class GorevController : Controller
    {
        // GET: Gorev
        [HttpPost] 
        public PartialViewResult Gorev(int kategoriId)
        {
            // Partial view açmamız gerekiyor ve aynı zamanda view tarafında partial açmamız gerekiyor diğer türlü sayfa açılmıyor.Görev ile ilgili olan herseyi yazmamız gerekiyor session hepsi listeleme ile ilgili olan herseyi
            DatabaseContext context = new DatabaseContext();

            Kisiler sessiondakiKisi = Session["kullanici"] as Kisiler;//  sessiondaki kullanıcı alma

            HomePageViewModel model = new HomePageViewModel();
                            //Burası session kişiye göre şart ama burda bu seferde ıd şu olan kategori için listelenme gercekleşiyor
            model.Gorevs = context.Gorevs.Where(x => x.KisiId == sessiondakiKisi.Id && x.KategoriId == kategoriId).ToList();
            foreach (var gorev in model.Gorevs)
            {
                GorevVeKategoriAdiListele gorev1 = new GorevVeKategoriAdiListele();

                gorev1.Gorevler = gorev;
                gorev1.KategoriAdi = context.Categoris.FirstOrDefault(x => x.Id == gorev.KategoriId).KategoriAdi;//Kategori ıd ile görevden gelen kategori ıd eşitse veritabanında gelen kategori adı görevde kategori ıd ile aynı .

                model.KategoriAdiListeleListesi.Add(gorev1);
            }
            return PartialView("Gorev", model); //Gorev html geciyoruz çünkü homapage listeleme işlemleriini table kısmını kopyalayıp görev listeleme işlemi gercekleştiriyoruz.
        }
        public ActionResult GorevEkle()
        {
            DatabaseContext context = new DatabaseContext();
            GorevModel model = new GorevModel();
            Kisiler sessiondakiKisi = Session["kullanici"] as Kisiler;//  sessiondaki kullanıcı alma

            model.Kategoriler = context.Categoris.Where(x => x.KisiId == sessiondakiKisi.Id).ToList();// sayfada kategorileri listelemek istediğimiz için kişiye ait kategorileri veritabanından alıp sayfaya gönderiyoruz. 

            return View(model);
        }
        [HttpPost]
        public ActionResult GorevEkle(HomePageViewModel model)
        {
            DatabaseContext context = new DatabaseContext();
            Gorev eklenecekgorev = new Gorev();
            Kisiler sessiondakiKisi = Session["kullanici"] as Kisiler;//  sessiondaki kullanıcı alma

            eklenecekgorev.GorevAdi = model.GorevAdi;
            eklenecekgorev.KategoriId = model.KategoriId;//veritabanın hangi categoride olduğunu yazıyor.
            eklenecekgorev.KisiId = sessiondakiKisi.Id;

            context.Gorevs.Add(eklenecekgorev);
            context.SaveChanges();
            return RedirectToAction("HomePage", "Home");// Bu işlem yapılırken hangi sayfaya girmek istiyorsak o sayfa ismi ve o sayfanın controller
        }
        // POP UP yapabilmek için metotların get veset isimleri farklı olmak zorunda ve partialview olmak zorunda.Parca sayfaya aça demek
        public PartialViewResult Update(int guncellenecekId)
        {
            DatabaseContext context = new DatabaseContext();

            var gorev = context.Gorevs.FirstOrDefault(x => x.Id == guncellenecekId);// java script gelecek güllenecek ıd

            GorevModel model = new GorevModel();

            Kisiler sessiondakiKisi = Session["kullanici"] as Kisiler;//  sessiondaki kullanıcı alma

            model.Kategoriler = context.Categoris.Where(x => x.KisiId == sessiondakiKisi.Id).ToList();// categorileri çekebilmek için session işlemini buraya yazmak zorudanayız
            model.GorevAdi = gorev.GorevAdi;
            model.KategoriId = gorev.KategoriId;
            model.GuncellenecekGorevId = gorev.Id;// burada güncelleme sayfasını açıyoruz güncellemiyoruz

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult UpdateGorev(GorevModel model) // Görev tablomuza göre güncellenecek
        {
            DatabaseContext context = new DatabaseContext();

            var gorev = context.Gorevs.FirstOrDefault(x=>x.Id == model.GuncellenecekGorevId);// neyin güncelleneceğiniz bilmediğimiz için model yeni bir değer ekliyoruz çekiyor model sınıfından 

            gorev.GorevAdi = model.GorevAdi;
            gorev.KategoriId = model.KategoriId;
            
            context.SaveChanges();

            return RedirectToAction("HomePage", "Home");
        }

        [HttpPost]
        // silinecek ıd buraya veriyoruz paremetre olarak
        public ActionResult Delete(int silinecekId)
        {     
            DatabaseContext context = new DatabaseContext();
            var gorev = context.Gorevs.FirstOrDefault(x=>x.Id == silinecekId);//Butona verdiğimiz görev ıd eger model ıd eşitse sil diyoruz. 
            context.Gorevs.Remove(gorev);
           
            context.SaveChanges();
            return RedirectToAction("HomePage", "Home");// homapage metoduna home controlunda
        }


  }
}