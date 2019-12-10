﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Models;
using Newtonsoft.Json;

namespace HW8.Controllers
{
    public class AthletesController : Controller
    {
        private RaceContext db = new RaceContext();

        // GET: Athletes
        public ActionResult Index()
        {
            return View(db.Athletes.ToList());
        }

        // GET: Athletes/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Athlete athlete = db.Athletes.Find(id);
            //if (athlete == null)
            //{
            //    return HttpNotFound();
            //} 
            var information = new
            {
/*
                 Athletename = db.Athletes.Where(s => s.ID == id).Select(s => s.Name),
                 Athletegender = db.TeamsandAthletes.Where(p => p.AthleteID == id).Select(p => p.Gender),
                 Racetime = db.RaceResults.Where(q => q.AthleteID == id).Select(q => q.RaceTime),*/
                Eventtitle = db.RaceResults.Where(r => r.AthleteID == id).Select(r => r.Event.EventTitle),
           /*     Meetdate = db.Locations.Where(m => m.ID == id).Select(r => r.MeetDate),
                Location = db.Locations.Where(i => i.ID == id).Select(i => i.Located)*/
            };

            string jsonString = JsonConvert.SerializeObject(information, Formatting.Indented);

            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
    };
}

// GET: Athletes/Create
public ActionResult Create()
{
    return View();
}

// POST: Athletes/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "ID,Name")] Athlete athlete)
{
    if (ModelState.IsValid)
    {
        db.Athletes.Add(athlete);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(athlete);
}

// GET: Athletes/Edit/5
public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Athlete athlete = db.Athletes.Find(id);
    if (athlete == null)
    {
        return HttpNotFound();
    }
    return View(athlete);
}

// POST: Athletes/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "ID,Name")] Athlete athlete)
{
    if (ModelState.IsValid)
    {
        db.Entry(athlete).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(athlete);
}

// GET: Athletes/Delete/5
public ActionResult Delete(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Athlete athlete = db.Athletes.Find(id);
    if (athlete == null)
    {
        return HttpNotFound();
    }
    return View(athlete);
}

// POST: Athletes/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
    Athlete athlete = db.Athletes.Find(id);
    db.Athletes.Remove(athlete);
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
