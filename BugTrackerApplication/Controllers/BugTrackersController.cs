using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTrackerApplication.Models;

namespace BugTrackerApplication.Controllers
{
    public class BugTrackersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BugTrackers
        public ActionResult Index()
        {
            return View(db.BugTrackers.ToList());
        }

        // GET: BugTrackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BugTracker bugTracker = db.BugTrackers.Find(id);
            if (bugTracker == null)
            {
                return HttpNotFound();
            }
            return View(bugTracker);
        }

        // GET: BugTrackers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BugTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] BugTracker bugTracker)
        {
            if (ModelState.IsValid)
            {
                db.BugTrackers.Add(bugTracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bugTracker);
        }

        // GET: BugTrackers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BugTracker bugTracker = db.BugTrackers.Find(id);
            if (bugTracker == null)
            {
                return HttpNotFound();
            }
            return View(bugTracker);
        }

        // POST: BugTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] BugTracker bugTracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bugTracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bugTracker);
        }

        // GET: BugTrackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BugTracker bugTracker = db.BugTrackers.Find(id);
            if (bugTracker == null)
            {
                return HttpNotFound();
            }
            return View(bugTracker);
        }

        // POST: BugTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BugTracker bugTracker = db.BugTrackers.Find(id);
            db.BugTrackers.Remove(bugTracker);
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
