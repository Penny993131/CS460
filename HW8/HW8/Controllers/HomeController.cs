using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Models;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        private RaceContext db = new RaceContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateAthlete()
        {
                return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAthlete([Bind(Include = "ID,Name,Gender")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(athlete);
        }

    }
}