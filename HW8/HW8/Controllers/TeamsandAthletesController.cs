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
    public class TeamsandAthletesController : Controller
    {
        private RaceContext db = new RaceContext();

        // GET: TeamsandAthletes
        public ActionResult Index()
        {
            var teamsandAthletes = db.TeamsandAthletes.Include(t => t.Athlete).Include(t => t.Team);
            return View(teamsandAthletes.ToList());
        }

        // GET: TeamsandAthletes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamsandAthlete teamsandAthlete = db.TeamsandAthletes.Find(id);
            if (teamsandAthlete == null)
            {
                return HttpNotFound();
            }
            return View(teamsandAthlete);
        }

        // GET: TeamsandAthletes/Create
        public ActionResult Create()
        {
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name");
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Title");
            return View();
        }

        // POST: TeamsandAthletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AthleteID,Gender,TeamID")] TeamsandAthlete teamsandAthlete, string athleteName)
        {
            

            if (ModelState.IsValid)
            {
                teamsandAthlete.AthleteID = db.Athletes.Where(s => s.Name.Contains(athleteName)).Select(s => s.ID).FirstOrDefault();
                db.TeamsandAthletes.Add(teamsandAthlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", teamsandAthlete.AthleteID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Title", teamsandAthlete.TeamID);
            return View(teamsandAthlete);
        }

        // GET: TeamsandAthletes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamsandAthlete teamsandAthlete = db.TeamsandAthletes.Find(id);
            if (teamsandAthlete == null)
            {
                return HttpNotFound();
            }
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", teamsandAthlete.AthleteID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Title", teamsandAthlete.TeamID);
            return View(teamsandAthlete);
        }

        // POST: TeamsandAthletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AthleteID,Gender,TeamID")] TeamsandAthlete teamsandAthlete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamsandAthlete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", teamsandAthlete.AthleteID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Title", teamsandAthlete.TeamID);
            return View(teamsandAthlete);
        }

        // GET: TeamsandAthletes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamsandAthlete teamsandAthlete = db.TeamsandAthletes.Find(id);
            if (teamsandAthlete == null)
            {
                return HttpNotFound();
            }
            return View(teamsandAthlete);
        }

        // POST: TeamsandAthletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamsandAthlete teamsandAthlete = db.TeamsandAthletes.Find(id);
            db.TeamsandAthletes.Remove(teamsandAthlete);
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
