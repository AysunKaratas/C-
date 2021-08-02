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
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            DatabaseContext context = new DatabaseContext(); //Veri tabanını oluşturmak için yazılmıştı..Select attığmız yer oluşması için
            var kisi = context.Kisiler.ToList();

            return View();
        }

        [HttpPost] // Yapılacak işlemler httpost ile çağırılır işleme geçirilir yapacagımız işlemleri httpost içinde gercekleştireceğiz.
        public ActionResult Login(LoginPageModel model)
        {
            DatabaseContext context = new DatabaseContext();

            var kisi = context.Kisiler.FirstOrDefault(x => x.TC == model.UserName && x.Sifre == model.Password);

            if (kisi != null)
            {
                Session["kullanici"] = kisi; //session tanımlama
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult KayitOl(KayitOlModel model)
        {
            if (ModelState.IsValid == true)
            {
                return View("Login");
            }

            DatabaseContext context = new DatabaseContext();

            Kisiler eklenecekKisi = new Kisiler();

            eklenecekKisi.TC = model.TC;
            eklenecekKisi.Sifre = model.Password;
            eklenecekKisi.Telefon = model.Telephone;

            context.Kisiler.Add(eklenecekKisi);

            context.SaveChanges();//   yazmazsak kodumuz çalışmaz kesinlikle yazmamız gerekiyor.

            return RedirectToAction("Login", "Home"); // Hangi methodu kullanacağız ve hangi controller olacagımız işlemleri gercekleştiriyor.
        }

        public ActionResult HomePage() // Tabloyu veritabanında göstermek için (Select işlemi)
        {
            DatabaseContext context = new DatabaseContext();

            Kisiler sessiondakiKisi = Session["kullanici"] as Kisiler;//  sessiondaki kullanıcı alma

            HomePageViewModel model = new HomePageViewModel();
            model.Categoris = context.Categoris.Where(x => x.KisiId == sessiondakiKisi.Id).ToList();
            
            model.TC = sessiondakiKisi.TC;

            return View(model);

            //DatabaseContext db = new DatabaseContext();
            // List<Categori> categoriler = db.Categoris.ToList();
           // KategorilerModel model = new KategorilerModel();
           // model.kategoriler = categoriler;
        
        }
        //public ActionResult Gorev()
        //{
          //  DatabaseContext db = new DatabaseContext();

         //   List<Gorev> gorevs = db.Gorevs.ToList();

            //GorevModel model = new GorevModel();

           // model.gorevler = gorevs;

            //return View(model);
       // }



        public ActionResult Sil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sil(SilModel model)
        {
            DatabaseContext context = new DatabaseContext();

            var kisi = context.Kisiler.FirstOrDefault(x => x.TC == model.TC);
            if (kisi != null)
            {
                context.Kisiler.Remove(kisi);

                context.SaveChanges();
            }

            //Home Page Açılışı
            //List<Categori> categoriler = context.Categoris.ToList();

            //KategorilerModel modelKategori = new KategorilerModel();

            //modelKategori.kategoriler = categoriler;

            //return View("HomePage", modelKategori);

            return RedirectToAction("HomePage", "Home");
        }
        public ActionResult Duzenle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Duzenle(DuzenleModel model)
        {
            DatabaseContext context = new DatabaseContext();
            var kisi = context.Kisiler.FirstOrDefault(x => x.TC == model.TC);
            if (kisi != null)
            {
                kisi.TC = model.TC;
                kisi.Sifre = model.Sifre;

                context.SaveChanges();
            }

            return RedirectToAction("HomePage", "Home");
        }

      
    }

}