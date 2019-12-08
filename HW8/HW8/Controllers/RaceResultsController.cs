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
    public class RaceResultsController : Controller
    {
        private RaceContext db = new RaceContext();

        // GET: RaceResults
        public ActionResult Index()
        {
            var raceResults = db.RaceResults.Include(r => r.Athlete).Include(r => r.Event).Include(r => r.Location);
            return View(raceResults.ToList());
        }

        // GET: RaceResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }
            return View(raceResult);
        }

        // GET: RaceResults/Create
        public ActionResult Create()
        {
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name");
            ViewBag.EventID = new SelectList(db.Events, "ID", "EventTitle");
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Located");
            return View();
        }

        // POST: RaceResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AthleteID,EventID,LocationID,RaceTime")] RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                db.RaceResults.Add(raceResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", raceResult.AthleteID);
            ViewBag.EventID = new SelectList(db.Events, "ID", "EventTitle", raceResult.EventID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Located", raceResult.LocationID);
            return View(raceResult);
        }

        // GET: RaceResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", raceResult.AthleteID);
            ViewBag.EventID = new SelectList(db.Events, "ID", "EventTitle", raceResult.EventID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Located", raceResult.LocationID);
            return View(raceResult);
        }

        // POST: RaceResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AthleteID,EventID,LocationID,RaceTime")] RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raceResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", raceResult.AthleteID);
            ViewBag.EventID = new SelectList(db.Events, "ID", "EventTitle", raceResult.EventID);
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "Located", raceResult.LocationID);
            return View(raceResult);
        }

        // GET: RaceResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }
            return View(raceResult);
        }

        // POST: RaceResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaceResult raceResult = db.RaceResults.Find(id);
            db.RaceResults.Remove(raceResult);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
