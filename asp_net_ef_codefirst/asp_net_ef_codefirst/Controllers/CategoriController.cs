using System;
using asp_net_ef_codefirst.Context;
using asp_net_ef_codefirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_net_ef_codefirst.Context.Managers;
using asp_net_ef_codefirst.ViewModels;

namespace asp_net_ef_codefirst.Controllers
{
    public class CategoriController : Controller
    {

        public ActionResult CategoriEkle()
        {
            return View();
        }
        // GET: Categori
        [HttpPost]
        public ActionResult CategoriEkle(HomePageViewModel model)
        {
            //TextBaxFour şeklinde listelemek yapmak istediğimiz için bu şekilde burası artık gorev model değil homeoPageModel olacak
            DatabaseContext context = new DatabaseContext();
            Categori eklenecekKategori = new Categori();

            Kisiler sessiondakiKisi = Session["kullanici"] as Kisiler;//  sessiondaki kullanıcı alma

            eklenecekKategori.KategoriAdi = model.KategoriAdi;
            eklenecekKategori.KisiId = sessiondakiKisi.Id;
            
            context.Categoris.Add(eklenecekKategori);
            context.SaveChanges();
            return RedirectToAction("HomePage", "Home"); //Bu işlem yeni sayfa yönlendirilmesi yapılırken metod(action) adı, controller adı yazılır.
        }

       
    }
}