using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;


namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        //create RGBColor Function
        public ActionResult RGBColor()
        {
            ViewBag.Red = Request.QueryString["Red"];
            ViewBag.Green = Request.QueryString["Green"];
            ViewBag.Blue = Request.QueryString["Blue"];
            // 3 variables
            int red, green, blue;
            red = Convert.ToInt32(Request.QueryString["Red"]);
            green = Convert.ToInt32(Request.QueryString["Green"]);
            blue = Convert.ToInt32(Request.QueryString["Blue"]);

            Color Cor1 = Color.FromArgb(red,green,blue);
            ViewBag.HX = Cor1.R.ToString("X2") + Cor1.G.ToString("X2") + Cor1.B.ToString("X2");
            return View("RGBColor");
        }
    }
}