using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class RaporController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Rapor
        public ActionResult Index()
        {
            var degerler = db.RaporlarTBL.ToList();
            return View(degerler);
        }

        public ActionResult OnayRaporlar()
        {

            var degerler = db.RaporlarTBL.Where(x => x.RaporDurum == true).ToList();

            return View(degerler);
        }
        public ActionResult OnaylanmayanRaporlar()
        {
            var degerler = db.RaporlarTBL.Where(x => x.RaporDurum == false).ToList();
            return View(degerler);
        }

        public ActionResult RaporListeYazdir()
        {
            var dosya = db.RaporlarTBL.ToList();

            return View(dosya);
        }

        [HttpGet]
        public ActionResult RaporEkle()
        {
            List<SelectListItem> labdeger = (from i in db.LaboratuvarlarTBL.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.LabKodu,
                                                 Value = i.LabID.ToString()


                                             }
                                         ).ToList();

            ViewBag.labdgr = labdeger;

            List<SelectListItem> persdeger = (from i in db.PersonellerTBL.Where(x=>x.PersonelTurID==1).ToList()
                                              select new SelectListItem
                                              {

                                                  Text = i.PersonelAd + " " + i.PersonelSoyad,
                                                  Value = i.PersonelID.ToString()
                                              }
                                            ).ToList();

            ViewBag.persdgr = persdeger;

            List<SelectListItem> numdeger = (from i in db.NumunelerTBL.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.NumuneAd + " " + i.NumuneSoyad,
                                                 Value = i.NumuneID.ToString()
                                             }

                                           ).ToList();

            ViewBag.numdgr = numdeger;

            List<SelectListItem> turdeger = (from i in db.RaporTurTBL.ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.RaporTur,
                                                 Value = i.RaporTurID.ToString()
                                             }

                                           ).ToList();

            ViewBag.turdgr = turdeger;

            return View();
        }

        [HttpPost]
        public ActionResult RaporEkle(RaporlarTBL r)
        {
            var d1 = db.LaboratuvarlarTBL.Where(x => x.LabID == r.LaboratuvarlarTBL.LabID).FirstOrDefault();
            r.LaboratuvarlarTBL = d1;

            var d2 = db.PersonellerTBL.Where(x => x.PersonelID == r.PersonellerTBL.PersonelID).FirstOrDefault();
            r.PersonellerTBL = d2;

            var d3 = db.NumunelerTBL.Where(x => x.NumuneID == r.NumunelerTBL.NumuneID).FirstOrDefault();
            r.NumunelerTBL = d3;

            var d4 = db.RaporTurTBL.Where(x => x.RaporTurID == r.RaporTurTBL.RaporTurID).FirstOrDefault();
            r.RaporTurTBL = d4;

            r.RaporDurum = false;
            //ilk ekelenen false yani onaylanmamış olucak

            db.RaporlarTBL.Add(r);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RaporGetir(int id)
        {
            var rapor = db.RaporlarTBL.Find(id);


            List<SelectListItem> labdeger = (from i in db.LaboratuvarlarTBL.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.LabKodu,
                                                 Value = i.LabID.ToString()


                                             }
                                         ).ToList();

            ViewBag.labdgr = labdeger;

            List<SelectListItem> persdeger = (from i in db.PersonellerTBL.ToList()
                                              select new SelectListItem
                                              {

                                                  Text = i.PersonelAd + " " + i.PersonelSoyad,
                                                  Value = i.PersonelID.ToString()
                                              }
                                            ).ToList();

            ViewBag.persdgr = persdeger;

            List<SelectListItem> numdeger = (from i in db.NumunelerTBL.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.NumuneAd + " " + i.NumuneSoyad,
                                                 Value = i.NumuneID.ToString()
                                             }

                                           ).ToList();

            ViewBag.numdgr = numdeger;


            List<SelectListItem> turdeger = (from i in db.RaporTurTBL.ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.RaporTur,
                                                 Value = i.RaporTurID.ToString()
                                             }

                                          ).ToList();

            ViewBag.turdgr = turdeger;

            rapor.RaporDurum = true;

            db.SaveChanges();


            return View("RaporGetir",rapor);
        }

        public ActionResult RaporOnayla(RaporlarTBL rpr)
        {
            var rapor = db.RaporlarTBL.Find(rpr.RaporID);

         

            return RedirectToAction("Index");
        }


    }
}