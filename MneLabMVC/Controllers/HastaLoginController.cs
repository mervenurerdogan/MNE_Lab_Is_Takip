using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class HastaLoginController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: HastaLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HastaGirisyap()
        {

            return View();
        }

        [HttpPost]
        public ActionResult HastaGirisyap(NumunelerTBL n)
        {
            var bilgiler = db.NumunelerTBL.FirstOrDefault(x => x.Mail == n.Mail && x.NumSifre1 == n.NumSifre1);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["NumuneID"] = bilgiler.NumuneID.ToString();
                Session["Mail"] = bilgiler.Mail.ToString();
                Session["NumuneAd"] = bilgiler.NumuneAd.ToString();
                Session["NumuneSoyad"] = bilgiler.NumuneSoyad.ToString();

                return RedirectToAction("Index", "HastaAnasayfa");

            }
            else
            {
                ViewBag.HataMesaj = "Hatalı Şifre veya Mail";
                return View();
            }

        }
    }
}