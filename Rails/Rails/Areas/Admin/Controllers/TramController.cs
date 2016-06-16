using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rails.Data;
using Rails.Models.Domain;

namespace Rails.Areas.Admin.Controllers
{
    [Authorize(Roles = "Beheerder")]
    public class TramController : Controller
    {
        private RailsDbContext db = new RailsDbContext();

        // GET: Admin/Tram
        public ActionResult Index()
        {
            var trams = db.Trams.Include(t => t.TramType);

            return View(trams.ToList());
        }

        // GET: Admin/Tram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tram tram = db.Trams.Find(id);
            if (tram == null)
            {
                return HttpNotFound();
            }
            return View(tram);
        }

        // GET: Admin/Tram/Create
        public ActionResult Create()
        {
            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description");
            return View();
        }

        // POST: Admin/Tram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Length,Condition,Dirty,Broken,DriverQualified,Available,TramTypeId")] Tram tram)
        {
            if (ModelState.IsValid)
            {
                db.Trams.Add(tram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            return View(tram);
        }

        // GET: Admin/Tram/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tram tram = db.Trams.Find(id);
            if (tram == null)
            {
                return HttpNotFound();
            }
            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            return View(tram);
        }

        // POST: Admin/Tram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Length,Condition,Dirty,Broken,DriverQualified,Available,TramTypeId")] Tram tram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            return View(tram);
        }

        // GET: Admin/Tram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tram tram = db.Trams.Find(id);
            if (tram == null)
            {
                return HttpNotFound();
            }
            return View(tram);
        }

        // POST: Admin/Tram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tram tram = db.Trams.Find(id);
            db.Trams.Remove(tram);
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
