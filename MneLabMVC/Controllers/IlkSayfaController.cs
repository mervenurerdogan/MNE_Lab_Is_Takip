using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MneLabMVC.Controllers
{
    public class IlkSayfaController : Controller
    {
        // GET: IlkSayfa
        public ActionResult Index()
        {//siteye girilinc eilk görülecek alan
            return View();
        }
    }
}