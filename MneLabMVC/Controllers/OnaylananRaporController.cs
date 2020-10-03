using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class OnaylananRaporController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: OnaylananRapor
        public ActionResult Index()
        {
            var değerler = db.OnaylananRaporTBL.ToList();

            return View(değerler);
        }

        [HttpGet]

        public ActionResult OnayEkle()
        {
            List<SelectListItem> rapordeger = (from i in db.RaporlarTBL.Where(x=>x.RaporDurum==false).ToList()

                                               select new SelectListItem
                                               {

                                                   Text = i.RaporNo,
                                                   Value = i.RaporID.ToString()
                                               }


                                             ).ToList();

            ViewBag.rapordgr = rapordeger;

            List<SelectListItem> persdeger = (from i in db.PersonellerTBL.Where(x=>x.PersonelTurID==1).ToList()

                                              select new SelectListItem
                                              {

                                                  Text = i.PersonelAd + ' ' + i.PersonelSoyad,
                                                  Value = i.PersonelID.ToString()

                                              }

                                            ).ToList();
            ViewBag.perdgr = persdeger;

            return View();
        }
        [HttpPost]

        public ActionResult OnayEkle(OnaylananRaporTBL i)
        {
            var d1 = db.RaporlarTBL.Where(x => x.RaporID == i.RaporlarTBL.RaporID).FirstOrDefault();
            i.RaporlarTBL = d1;

            var d2 = db.PersonellerTBL.Where(x => x.PersonelID == i.PersonellerTBL.PersonelID).FirstOrDefault();
            i.PersonellerTBL = d2;

            i.OnayRaporDurum = true;

            db.OnaylananRaporTBL.Add(i);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

      
      

    }
}