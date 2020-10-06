using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;
using System.Web.Security;

namespace MneLabMVC.Controllers
{
    public class LoginController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GirisYap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(PersonellerTBL p)
        {

            var bilgiler = db.PersonellerTBL.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre1 == p.Sifre1);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);

                Session["PersonelID"] = bilgiler.PersonelID.ToString();
                Session["Mail"] = bilgiler.Mail.ToString();
                Session["PersonelAd"] = bilgiler.PersonelAd.ToString();
                Session["PersonelSoyad"] = bilgiler.PersonelSoyad.ToString();

                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                ViewBag.HataMesaj = "Hatalı Mail veya Şifre";
                return View();
            }

        
        }
    }
}