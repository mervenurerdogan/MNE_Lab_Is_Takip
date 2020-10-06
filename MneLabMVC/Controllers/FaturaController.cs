using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;
namespace MneLabMVC.Controllers
{
    public class FaturaController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Fatura
        public ActionResult Index()
        {
            var degerler = db.FaturalarTBL.ToList();
            //ödenen ödenmeyen tüm faturalar
            return View(degerler);
        }

        public ActionResult FaturaListeYazdir()
        {

            var fatura = db.FaturalarTBL.ToList();
            return View(fatura);
        }

        public ActionResult OdenmeyenFatura()
        {
            var degerler = db.FaturalarTBL.Where(x => x.FaturaDurumu == false).ToList();
            //durumu false olanalra yani ödenmeyenleri listeleyecek
            return View(degerler);
        }

        public ActionResult OdenenFaturalar()
        {
            var degerler = db.FaturalarTBL.Where(x => x.FaturaDurumu == true).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {

            List<SelectListItem> labdeger = (from i in db.LaboratuvarlarTBL.ToList()

                                           select new SelectListItem
                                           {
                                               Text = i.LabKodu,
                                               Value = i.LabID.ToString()


                                           }
                                         ).ToList();

            ViewBag.labdgr = labdeger;

            List<SelectListItem> persdeger = (from i in db.PersonellerTBL.Where(x=>x.PersonelTurID==4).ToList()
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

            List<SelectListItem> turdeger = (from i in db.FaturaTurTBL.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.FaturaTur,
                                                 Value = i.FaturaTurID.ToString()
                                             }

                                           ).ToList();
            ViewBag.turdgr = turdeger;

            return View();
        }
         [HttpPost]
        public ActionResult FaturaEkle(FaturalarTBL f)
        {
            var d1 = db.LaboratuvarlarTBL.Where(x => x.LabID == f.LaboratuvarlarTBL.LabID).FirstOrDefault();
            f.LaboratuvarlarTBL = d1;

            var d2 = db.PersonellerTBL.Where(x => x.PersonelID == f.PersonellerTBL.PersonelID).FirstOrDefault();
            f.PersonellerTBL = d2;

            var d3 = db.NumunelerTBL.Where(x => x.NumuneID == f.NumunelerTBL.NumuneID).FirstOrDefault();
            f.NumunelerTBL = d3;

            var d4 = db.FaturaTurTBL.Where(x => x.FaturaTurID == f.FaturaTurTBL.FaturaTurID).FirstOrDefault();
            f.FaturaTurTBL = d4;

            f.FaturaDurumu = false;
            //kesilen fatura ilk durumu false çünkü ödenmedi

            db.FaturalarTBL.Add(f);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    public ActionResult FaturaBilgiGetir(int id){
            var fatura = db.FaturalarTBL.Find(id);


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


            fatura.FaturaDurumu = true;

            db.SaveChanges();




            return View("FaturaBilgiGetir",fatura);
        }

        public ActionResult FaturaOdemeYap(FaturalarTBL ftr)
        {
            var fatura = db.FaturalarTBL.Find(ftr.FaturaID);
            //fatura.FaturaNo = ftr.FaturaNo;
            //fatura.FaturaTarih = ftr.FaturaTarih;
            //fatura.FaturaTutar = ftr.FaturaTutar;

            //var d1 = db.LaboratuvarlarTBL.Where(x => x.LabID == ftr.LaboratuvarlarTBL.LabID).FirstOrDefault();
            //fatura.LabID = d1.LabID;

            //var d2 = db.PersonellerTBL.Where(x => x.PersonelID == ftr.PersonellerTBL.PersonelID).FirstOrDefault();
            //fatura.PersonelID = d2.PersonelID;

            //var d3 = db.NumunelerTBL.Where(x => x.NumuneID == ftr.NumunelerTBL.NumuneID).FirstOrDefault();
            //fatura.NumuneID = d3.NumuneID;

          


            return RedirectToAction("Index");
        }

    }
}