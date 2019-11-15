using HW6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private WWIContext db = new WWIContext();
        public ActionResult Index(string name)
        {

            return View(db.StockItems.Where(s => s.StockItemName.Contains(name)).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}




