using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;
using PagedList;
using PagedList.Mvc;

namespace MneLabMVC.Controllers
{
    public class OdenenFaturalarController : Controller
    {

        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: OdenenFaturalar
        public ActionResult Index(int sayfa=1)
        {
            var degeler = db.OdenenFaturaTBL.ToList().ToPagedList(sayfa,5);
            
            return View(degeler);
        }

        [HttpGet]
        public ActionResult OdemeYap()
        {

            List<SelectListItem> faturadeger = (from i in db.FaturalarTBL.ToList()

                                                select new SelectListItem
                                                {

                                                    Text = i.FaturaNo,
                                                    Value = i.FaturaID.ToString()

                                                }

                                              ).ToList();
            ViewBag.ftrdgr = faturadeger;

            List<SelectListItem> perdeger = (from i in db.PersonellerTBL.Where(x=>x.PersonelTurID==4).ToList()

                                             select new SelectListItem
                                             {

                                                 Text = i.PersonelAd + ' ' + i.PersonelSoyad,
                                                 Value = i.PersonelID.ToString()
                                             }

                                           ).ToList();
            ViewBag.perdgr = perdeger;

            return View();
        }

        public ActionResult OdemeYap(OdenenFaturaTBL o)
        {
            var d1 = db.PersonellerTBL.Where(x => x.PersonelID == o.PersonellerTBL.PersonelID).FirstOrDefault();
            o.PersonellerTBL = d1;

            var d2 = db.FaturalarTBL.Where(x => x.FaturaID == o.FaturalarTBL.FaturaID).FirstOrDefault();
            o.FaturalarTBL = d2;

            o.FaturaOdenmeDurum = true;

            db.OdenenFaturaTBL.Add(o);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}