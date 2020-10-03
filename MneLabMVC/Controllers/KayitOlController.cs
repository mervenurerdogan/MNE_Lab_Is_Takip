using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class KayitOlController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: KayitOl
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Kayit()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Kayit(PersonellerTBL p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }

         


            p.PersonelDurum = false;
            p.PersonelSilmeDurum = true;
            db.PersonellerTBL.Add(p);
            db.SaveChanges();
            ViewBag.BasariliKayit = "Kayıt İşlemi Başarılı";
            return View();
        }


    }
    } 
