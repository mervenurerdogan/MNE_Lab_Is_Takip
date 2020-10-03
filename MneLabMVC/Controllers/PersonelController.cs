using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;


namespace MneLabMVC.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();


        public ActionResult Index()
        {
            var perdeger = db.PersonellerTBL.Where(x=>x.PersonelSilmeDurum==true).ToList();
            //sistem de kayıtlı bütün personeli gösterir
            
            return View(perdeger);
        }

     

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> turdeger = (from i in db.PersonelTurTBL.ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.PersonelTur,
                                                 Value = i.PersonelTurID.ToString()
                                             }

                                           ).ToList();

            ViewBag.turdgr = turdeger;

            List<SelectListItem> labdeger = (from i in db.LaboratuvarlarTBL.ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.LabKodu,
                                                 Value = i.LabID.ToString()

                                             }
                                           ).ToList();
            ViewBag.labdgr = labdeger;



            return View();
        }
        [HttpPost]

        public ActionResult PersonelEkle(PersonellerTBL p)
        {
            var d1 = db.PersonelTurTBL.Where(x => x.PersonelTurID == p.PersonelTurTBL.PersonelTurID).FirstOrDefault();
            p.PersonelTurTBL = d1;

            var d2 = db.LaboratuvarlarTBL.Where(x => x.LabID == p.LaboratuvarlarTBL.LabID).FirstOrDefault();
            p.LaboratuvarlarTBL = d2;

            p.PersonelDurum = false;
            //false olma sebebi yeni eklenen izinli olamaz
            p.PersonelSilmeDurum = true;
            //silme işleminden önce eklerken hep true 

            db.PersonellerTBL.Add(p);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personelbul = db.PersonellerTBL.Find(id);
            //db.PersonellerTBL.Remove(personelbul);
            personelbul.PersonelSilmeDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}