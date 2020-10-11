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
    public class Faturalarin_HastaController : Controller
    {
        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Faturalarin_Hasta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HastaFaturalar(int id,int sayfa=1)
        {
            var fatura = db.FaturalarTBL.Where(x => x.NumuneID == id).ToList().ToPagedList(sayfa,1);

            return View(fatura);
        }
    }
}