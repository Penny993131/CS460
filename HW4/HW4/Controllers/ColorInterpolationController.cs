using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace HW4.Controllers
{
    public class ColorInterpolationController : Controller
    {
        // GET: ColorInterpolation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateColor()
        {
            return View();

        }
        [HttpPost]
        // create CreateColor Function
        public ActionResult CreateColor(string color1, string color2, int numofcolors)
        {
            if (ModelState.IsValid)
            {
                Color colorone = ColorTranslator.FromHtml(color1);// use ColorTranslator.FromHtml
                Color colortwo = ColorTranslator.FromHtml(color2);

                
                double myH1, myS1, myV1;
                ColorToHSV(colorone, out myH1, out myS1, out myV1);
                Color copy1 = ColorFromHSV(myH1, myS1, myV1);

                double myH2, myS2, myV2;
                ColorToHSV(colortwo, out myH2, out myS2, out myV2);
                Color copy2 = ColorFromHSV(myH2, myS2, myV2);

                //create an empty list to store colors
                IList<colorlist> output = new List<colorlist>();
                string tempcolor = ColorTranslator.ToHtml(copy1);

                //step size
                double stepMyH, stepMyS, stepMyV;
                if (myH2 > myH1)
                {
                    stepMyH = Math.Abs(myH2 - myH1) / numofcolors;

                }
                else
                {
                    stepMyH = Math.Abs(myH2 - myH1) / (numofcolors) * -1;
                }

                if (myS2 > myS1)
                {

                    stepMyS = Math.Abs(myS2 - myS1) / numofcolors;
                }
                else
                {
                    stepMyS = Math.Abs(myS2 - myS1) / (numofcolors) * -1;
                }
                if (myV2 > myV1)
                {
                    stepMyV = Math.Abs(myV2 - myV1) / numofcolors;

                }
                else
                {
                    stepMyV = Math.Abs(myV2 - myV1) / (numofcolors) * -1;
                }
                for (int i = 0; i < numofcolors; i++)
                {
                    double myHval = myH1 + (i * stepMyH);
                    double mySval = myS1 + (i * stepMyS);
                    double myVval = myV1 + (i * stepMyV);

                    Color colorT = ColorFromHSV(myHval, mySval, myVval);
                    tempcolor = ColorTranslator.ToHtml(colorT);
                    output.Add(new colorlist { htmlcolor = tempcolor });
                }

                ViewBag.ShowColors = output;
                ViewBag.Success = true;

                return View("CreateColor");
            }
            else{
                return View();
            }

        }
        // get set functions
        public struct colorlist
        {
            public string htmlcolor { get; set; }

        }
        // From Greg's answer: https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175
        // And Wikipedia: https://en.wikipedia.org/wiki/HSL_and_HSV
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

    }
}