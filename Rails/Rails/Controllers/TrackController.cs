﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rails.Models;
using Rails.Models.Binders;


namespace Rails.Controllers
{
    public class TrackController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public TrackViewModel GetViewModel(Track from)
        {
            return new TrackViewModel
            {
                Track = from,
                Depot = new DepotViewModel { Depot = from.Depot },
                Sectors = db.Sectors.Where(s => s.TrackId == from.Id).Select(s => new SectorViewModel { Sector = s })
            };
        }

        // GET: Track
        public ActionResult Index()
        {
            return View(db.Tracks.Select(GetViewModel));
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepotId,Number,Length,Accessible,InOutTrack")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }


            TrackEditViewModel model = new TrackEditViewModel
            {
                Accessible = Convert.ToBoolean(track.Accessible),
                DepotId = track.DepotId,
                Depots = db.Depots.ToList(),
                Trams = db.Trams.ToList(),
                Number = track.Number,
                InOutTrack = Convert.ToBoolean(track.InOutTrack),
                Length = track.Length,
                Sectors = track.Sectors
            };

            return View(model);
        }

        // POST: Track/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrackEditViewModel model)
        {
            Track original = db.Tracks.First(x => x.Number == model.Number);
            original.DepotId = model.DepotId;
            original.Number = model.Number;
            original.Length = model.Length;
            original.Accessible = Convert.ToInt32(model.Accessible);
            original.InOutTrack = Convert.ToInt32(model.InOutTrack);


            if (ModelState.IsValid)
            {

                db.Entry(original).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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
