﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class LabController : Controller
    {

        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();

        // GET: Lab
        public ActionResult Index()
        {
            var deger = db.LaboratuvarlarTBL.Where(x=>x.LabDurum==true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult LabEkle()
        {

            List<SelectListItem> degerlab = (from i in db.LabTurTBL.ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.LabTur,
                                                 Value = i.LabTurID.ToString()

                                             }
                                           ).ToList();
            ViewBag.dgrlab = degerlab;
            return View();
        }

        [HttpPost]
        public ActionResult LabEkle(LaboratuvarlarTBL l)
        {

            var d1 = db.LabTurTBL.Where(x => x.LabTurID == l.LabTurTBL.LabTurID).FirstOrDefault();
            l.LabTurTBL = d1;

            l.LabDurum = true;
            //eklerken lab durumu hep true geslin
            db.LaboratuvarlarTBL.Add(l);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LabGetir(int id)
        {
            var lab = db.LaboratuvarlarTBL.Find(id);
            List<SelectListItem> labgnc = (from i in db.LabTurTBL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.LabTur,
                                               Value = i.LabTurID.ToString()


                                           }


                                         ).ToList();

            ViewBag.tudgr = labgnc;

            return View("LabGetir", lab);
        }

        public ActionResult LabGuncelle(LaboratuvarlarTBL l1)
        {
            var lab = db.LaboratuvarlarTBL.Find(l1.LabKodu);
            lab.LabKodu = l1.LabKodu;
            var labtur = db.LabTurTBL.Where(m => m.LabTurID == l1.LabTurTBL.LabTurID).FirstOrDefault();
            lab.LabTurID = labtur.LabTurID;
            db.SaveChanges();




            return RedirectToAction("Index");
        }
    }

}
