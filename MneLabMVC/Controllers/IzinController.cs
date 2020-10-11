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
    public class IzinController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();

        // GET: Izin
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.IzınTBL.Where(x => x.PersonelIzinDurumu == true).ToList().ToPagedList(sayfa,5);
            //durumu true olan yani izinli olanları gösterecek
            return View(degerler);
        }
        [HttpGet]
        public ActionResult IzinAl()
        {
            List<SelectListItem> degerper = (from i in db.PersonellerTBL.Where(p=>p.PersonelDurum==false).ToList()
                                             //durumu false olanlar yani iznli olmayan personeli getir
                                           select new SelectListItem
                                           {
                                               Text = i.PersonelAd + ' ' + i.PersonelSoyad,
                                               Value = i.PersonelID.ToString()


                                           }

                                         ).ToList();

            ViewBag.dgrper = degerper;


            return View();
        }

        [HttpPost]
        public ActionResult IzinAl(IzınTBL i)
        {

            var d1 = db.PersonellerTBL.Where(x => x.PersonelID == i.PersonellerTBL.PersonelID).FirstOrDefault();
            i.PersonellerTBL = d1;
            i.PersonelIzinDurumu = true;
            //ekleme yapınca yani izin ekle deyince otomatik true alacak

            db.IzınTBL.Add(i);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult IzinGetir(int id)
        {
            var izin = db.IzınTBL.Find(id);

            return View("IzinGetir",izin);
        }

        public ActionResult IzinIptal(IzınTBL i)
        {
            var izin = db.IzınTBL.Find(i.IzinID);

            return RedirectToAction("Index");

        }
    }
}