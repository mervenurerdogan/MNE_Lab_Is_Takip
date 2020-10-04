using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    
    public class AnasayfaController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult ProfilGunGetir( )
        {
            var perMail = (string)Session["Mail"];
            //mail hem postta hem get de alınıyor.
            var degerler = db.PersonellerTBL.FirstOrDefault(z => z.Mail == perMail);

           

            List<SelectListItem> pertur = (from i in db.PersonelTurTBL.ToList()

                                           select new SelectListItem
                                           
                                           {
                                               Text = i.PersonelTur,
                                               Value = i.PersonelTurID.ToString()

                                           }

                                        ).ToList();
            ViewBag.dgrtur = pertur;


            List<SelectListItem> labsec = (from i in db.LaboratuvarlarTBL.ToList()

                                           select new SelectListItem
                                           {

                                               Text = i.LabKodu,
                                               Value = i.LabID.ToString()


                                           }

                                         ).ToList();

            ViewBag.dgrlab = labsec;

           

            return View( degerler);
        }

        
        public ActionResult ProfilGuncelle(PersonellerTBL p)
        {
            if (!ModelState.IsValid)
            {
                return View("ProfilGunGetir");

            }
          
                var kullanici = (string)Session["Mail"];
                //string olrak maili taşıycaz
                var personel = db.PersonellerTBL.FirstOrDefault(x => x.Mail == kullanici);
                personel.Sifre1 = p.Sifre1;
                personel.Sifre2 = p.Sifre2;
                personel.PersonelAd = p.PersonelAd;
                personel.PersonelSoyad = p.PersonelSoyad;
                personel.KullanıcıAdi = p.KullanıcıAdi;


                var d1 = db.PersonelTurTBL.Where(x => x.PersonelTurID == p.PersonelTurTBL.PersonelTurID).FirstOrDefault();
                p.PersonelTurTBL = d1;


                var d2 = db.LaboratuvarlarTBL.Where(y => y.LabID == p.LaboratuvarlarTBL.LabID).FirstOrDefault();
                p.LaboratuvarlarTBL = d2;

                personel.PersonelTurID = d1.PersonelTurID;
                personel.LabID = d2.LabID;

                db.SaveChanges();
               

                return RedirectToAction("ProfilGunGetir");
          
           
        }

       
               
         
           
      

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
    }
}