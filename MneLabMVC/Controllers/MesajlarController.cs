﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class MesajlarController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Mesajlar
        public ActionResult Index()
        {
            var personelMail = (string)Session["Mail"].ToString();
            var mesajlar = db.MesajlarTBL.Where(x => x.Alıcı == personelMail.ToString()).ToList();
            //gelen mesajlar
            return View(mesajlar);
        }

        public ActionResult GidenMesaj()
        {
            var personelMail = (string)Session["Mail"].ToString();
            var mesajlar = db.MesajlarTBL.Where(x => x.Gonderen == personelMail.ToString()).ToList();

            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(MesajlarTBL msj)
        {
            var personelMail = (string)Session["Mail"].ToString();
            //gönderini eklememk için ekledik session nu
            msj.Gonderen =personelMail.ToString();
            msj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.MesajlarTBL.Add(msj);
            db.SaveChanges();

            return RedirectToAction("YeniMesaj");
        }
    }
}