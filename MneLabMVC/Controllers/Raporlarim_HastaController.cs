using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MneLabMVC.Models.Entitys;
using System.Web.SessionState;
using PagedList;
using PagedList.Mvc;

namespace MneLabMVC.Controllers
{
    public class Raporlarim_HastaController : Controller
    {

        LaboratuvarDBEntities2 db = new LaboratuvarDBEntities2();
        // GET: Raporlarim_Hasta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HastaRaporlar(int  id,int sayfa=1)
        {
            
                var raporlarim = db.RaporlarTBL.Where(x => x.NumuneID==id).ToList().ToPagedList(sayfa,5);
                return View(raporlarim);
          
       

           
        }
    }
}