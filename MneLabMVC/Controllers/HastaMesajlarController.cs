using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class HastaMesajlarController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: HastaMesajlar
        public ActionResult Index()
        {
            var hastamail = (string)Session["Mail"].ToString();
            var mesajlar = db.MesajlarTBL.Where(x => x.Alıcı == hastamail.ToString()).ToList();
            //gelen mesajlar
            return View(mesajlar);
        }

        public ActionResult GidenMesaj()
        {

            var hastamesaj = (string)Session["Mail"].ToString();
            var mesajlar = db.MesajlarTBL.Where(x => x.Gonderen == hastamesaj.ToString()).ToList();
            return View(mesajlar);

        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]

        public ActionResult YeniMesaj(MesajlarTBL m)
        {

            var hastamail = (string)Session["Mail"].ToString();
            //göndereni eklemek için maili aldık
            m.Gonderen = hastamail.ToString();
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.MesajlarTBL.Add(m);
            db.SaveChanges();

            return RedirectToAction("YeniMesaj");
        }


    }
}