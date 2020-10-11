using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;
using PagedList;
using PagedList.Mvc;

namespace MneLabMVC.Controllers
{
    public class CihazMalzController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();

        // GET: CihazMalz
        public ActionResult Index(int sayfa=1)
        {
            var malzdeger = db.MalzemelerTBL.ToList().ToPagedList(sayfa,5);
            return View(malzdeger);
        }

        [HttpGet]
        public ActionResult MalzemeEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MalzemeEkle(MalzemelerTBL m)
        {



            db.MalzemelerTBL.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MalzemeGetir(int id)
        {
            var malzeme = db.MalzemelerTBL.Find(id);


            return View("MalzemeGetir",malzeme);
        }
        [HttpPost]
        public ActionResult MalzemeGuncelle(MalzemelerTBL m)
        {

            if (!ModelState.IsValid)
            {
                return View("MalzemeGetir");

            }
            var malgun = db.MalzemelerTBL.Find(m.MalzemeID);
            malgun.Malzeme = m.Malzeme;
            malgun.MalzemeDetay = m.MalzemeDetay;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}