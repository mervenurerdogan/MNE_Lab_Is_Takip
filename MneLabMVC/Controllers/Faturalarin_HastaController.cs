using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;

namespace MneLabMVC.Controllers
{
    public class Faturalarin_HastaController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Faturalarin_Hasta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HastaFaturalar(int id)
        {
            var fatura = db.FaturalarTBL.Where(x => x.NumuneID == id).ToList();

            return View(fatura);
        }
    }
}