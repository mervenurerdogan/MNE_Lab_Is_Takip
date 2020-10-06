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
    public class NumuneController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();

        // GET: Numune
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.NumunelerTBL.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult NumuneEkle()
        {
            List<SelectListItem> degerler = (from i in db.PersonellerTBL.Where(x=>x.PersonelTurTBL.PersonelTurID==2).ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.PersonelAd + ' ' + i.PersonelSoyad,
                                                 Value = i.PersonelID.ToString()

                                             }

                                           ).ToList();
            ViewBag.dgrper = degerler;


            List<SelectListItem> numdeger = (from i in db.NumuneTurTBL.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = i.NumuneTur,
                                                 Value = i.NumuneTurID.ToString()
                                             }


                                           ).ToList();
            ViewBag.dgrnum = numdeger;


            List<SelectListItem> labdeger = (from i in db.LaboratuvarlarTBL.ToList()

                                           select new SelectListItem
                                           {
                                               Text = i.LabKodu,
                                               Value = i.LabID.ToString()

                                           }
                                         ).ToList();
            ViewBag.dgrlab = labdeger;

            return View();

        }

        [HttpPost]
        public ActionResult NumuneEkle(NumunelerTBL n)
        {
            var d1 = db.PersonellerTBL.Where(x => x.PersonelID == n.PersonellerTBL.PersonelID).FirstOrDefault();
            n.PersonellerTBL = d1;

            var d2 = db.LaboratuvarlarTBL.Where(x => x.LabID == n.LaboratuvarlarTBL.LabID).FirstOrDefault();
            n.LaboratuvarlarTBL = d2;

            var d3 = db.NumuneTurTBL.Where(x => x.NumuneTurID == n.NumuneTurTBL.NumuneTurID).FirstOrDefault();
            n.NumuneTurTBL = d3;

            db.NumunelerTBL.Add(n);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}