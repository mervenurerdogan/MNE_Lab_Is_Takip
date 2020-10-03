using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class HastaAnasayfaController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();

        // GET: HastaAnasayfa
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult HastaProfilGunGetir()
        {

            var numMail = (string)Session["Mail"];
            var degerler = db.NumunelerTBL.FirstOrDefault(z => z.Mail == numMail);
            return View(degerler);
        }

        public ActionResult HastaProfilGuncelle(NumunelerTBL n)
        {

            if (!ModelState.IsValid)
            {

                return View("HastaProfilGunGetir");
            }

            var kullanici = (string)Session["Mail"];

            var numune = db.NumunelerTBL.FirstOrDefault(x => x.Mail == kullanici);
            numune.NumSifre1 = n.NumSifre1;
            numune.NumSifre2 = n.NumSifre2;
            numune.NumuneAd = n.NumuneAd;
            numune.NumuneSoyad = n.NumuneSoyad;

            db.SaveChanges();
          
            return RedirectToAction("HastaProfilGunGetir");
          

        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("HastaGirisYap", "HastaLogin");
        }

    }
}