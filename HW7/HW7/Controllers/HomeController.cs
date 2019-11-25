using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult RandomNumbers(int? id = 100)
        {
            Random gen = new Random();
            var data = new
            {
                message = "Random Numbers API",
                num = (int)id,
                numbers = Enumerable.Range(1, (int)id).Select(x => gen.Next(1000))
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}