using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;
using PagedList;
using PagedList.Mvc;

namespace MneLabMVC.Controllers
{
    public class DeneyController : Controller
    {

        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Deney
        public ActionResult Index(int sayfa=1)
        {
            var deneydeger = db.DeneylerTBL.ToList().ToPagedList(sayfa,5);
            return View(deneydeger);
        }

        public ActionResult ListeYazdır()
        {
            var dosya = db.DeneylerTBL.ToList();
            return View(dosya);
        }

        public ActionResult OnaylananDeneyler(int sayfa=1)
        {
            var degerler = db.DeneylerTBL.Where(x => x.DeneyDurum == true).ToList().ToPagedList(sayfa,5);

            return View(degerler);

        }

        [HttpGet]
        public ActionResult DeneyEkle()
        {
            List<SelectListItem> dnytur = (from i in db.DeneyTurTBL.ToList()
                                           select new SelectListItem
                                           {

                                               Text = i.DeneyTur,
                                               Value = i.DeneyTurID.ToString()
                                           }
                                         ).ToList();
            ViewBag.dnyturdgr = dnytur;

            List<SelectListItem> deneyaper = (from i in db.PersonellerTBL.Where(x=>x.PersonelTurID==2 || x.PersonelTurID==3).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.PersonelAd + ' ' + i.PersonelSoyad,
                                                  Value = i.PersonelID.ToString()

                                              }

                                            ).ToList();
            ViewBag.dgrper = deneyaper;




            List<SelectListItem> numdeger = (from i in db.NumunelerTBL.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.NumuneAd + ' ' + i.NumuneSoyad,
                                                 Value = i.NumuneID.ToString()

                                             }
                      ).ToList();
            ViewBag.numdgr = numdeger;

            List<SelectListItem> numturdeger = (from i in db.NumuneTurTBL.ToList()

                                                select new SelectListItem
                                                {
                                                    Text = i.NumuneTur,
                                                    Value = i.NumuneTurID.ToString()

                                                }


                                              ).ToList();

            ViewBag.numturdgr = numturdeger;

            List<SelectListItem> rapordeger = (from i in db.RaporTurTBL.ToList()
                                               select new SelectListItem
                                               {
                                                   Text=i.RaporTur,
                                                   Value=i.RaporTurID.ToString()

                                               }

                                             ).ToList();
            ViewBag.rapordgr = rapordeger;

            List<SelectListItem> faturadeger = (from i in db.FaturaTurTBL.ToList()
                                                select new SelectListItem
                                                {

                                                    Text = i.FaturaTur,
                                                    Value = i.FaturaTurID.ToString()

                                                }

                                              ).ToList();

            ViewBag.fatdgr = faturadeger;

            List<SelectListItem> maldeger = (from i in db.MalzemelerTBL.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Malzeme,
                                                 Value = i.MalzemeID.ToString()

                                             }

                                           ).ToList();
            ViewBag.dgrmal = maldeger;


            return View();


        }

        [HttpPost]
        public ActionResult DeneyEkle(DeneylerTBL d)
        {
            var d1 = db.DeneyTurTBL.Where(x => x.DeneyTurID == d.DeneyTurTBL.DeneyTurID).FirstOrDefault();
            d.DeneyTurTBL = d1;

            var d2 = db.PersonellerTBL.Where(x => x.PersonelID == d.PersonellerTBL.PersonelID).FirstOrDefault();
            d.PersonellerTBL = d2;

            var d3 = db.NumunelerTBL.Where(x => x.NumuneID == d.NumunelerTBL.NumuneID).FirstOrDefault();
            d.NumunelerTBL = d3;

            var d4 = db.NumuneTurTBL.Where(x => x.NumuneTurID == d.NumuneTurTBL.NumuneTurID).FirstOrDefault();
            d.NumuneTurTBL = d4;

            var d5 = db.RaporTurTBL.Where(x => x.RaporTurID == d.RaporTurTBL.RaporTurID).FirstOrDefault();
            d.RaporTurTBL = d5;

            var d6 = db.FaturaTurTBL.Where(x => x.FaturaTurID == d.FaturaTurTBL.FaturaTurID).FirstOrDefault();
            d.FaturaTurTBL = d6;

            var d7 = db.MalzemelerTBL.Where(x => x.MalzemeID == d.MalzemelerTBL.MalzemeID).FirstOrDefault();
            d.MalzemelerTBL = d7;


         

            d.DeneyDurum = false;
            //ilk eklerken false çünkü sonuçlanmamış oluyor.

            db.DeneylerTBL.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}