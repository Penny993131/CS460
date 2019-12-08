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
        // GET: Athletes/Create
        public ActionResult CreateAthlete()
        {
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Teams/Create
        public ActionResult CreateTeam()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTeam([Bind(Include = "ID,Title,Coach")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(team);
        }
        public ActionResult CreateTeamandAthlete()
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
        public ActionResult CreateTeamandAthlete([Bind(Include = "ID,TeamID,AthleteID")] TeamsandAthlete teamsandAthlete)
        {
            if (ModelState.IsValid)
            {
                db.TeamsandAthletes.Add(teamsandAthlete);
                db.SaveChanges();
                return RedirectToAction("index","TeamsandAthletes");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "Name", teamsandAthlete.AthleteID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Title", teamsandAthlete.TeamID);
            return View(teamsandAthlete);
        }


    }
}