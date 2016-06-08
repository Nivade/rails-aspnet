using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rails.Models;
using Rails.Services;


namespace Rails.Controllers
{
    public class SectorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sector
        public ActionResult Index()
        {

            IEnumerable<SectorViewModel> models = db.Sectors.Include(s => s.Track).Include(s => s.Tram).Select(s => new SectorViewModel());

            return View(models);
        }

        // GET: Sector/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            SectorViewModel model = new SectorViewModel
            {
                Id = sector.Id
            };
            return View(model);
        }

        // GET: Sector/Create
        public ActionResult Create()
        {
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Id");
            ViewBag.TramId = new SelectList(db.Trams, "Id", "Id");
            return View();
        }

        // POST: Sector/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Accessible,Blocked,TramId,TrackId")] Sector sector)
        {
            SectorService sectorService = new SectorService(db);

            sectorService.Add(sector.TrackId.Value);

            if (ModelState.IsValid)
            {
                db.Sectors.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Id", sector.TrackId);
            return View(sector);
        }

        // POST: Sector/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                SectorService sectorService = new SectorService(db);

                if (model.TrackId != null)
                    sectorService.Add(model.TrackId.Value);

                return RedirectToAction("Index");
            }

            //ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Id", sector.TrackId);
            return View("d");
        }

        // GET: Sector/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Id", sector.TrackId);
            return View(sector);
        }


        // POST: Place/
        public PartialViewResult Place(int? id)
        {
            if (id == null)
                return PartialView("Error");

            TramPlacementViewModel model = new TramPlacementViewModel
            {
                SectorId = id.Value,
                Trams = db.Trams.ToList()

            };

            return PartialView("~/Views/Tram/_Placement.cshtml", model);
        }



        public ActionResult Block(int? id)
        {
            return Content("Error");
        }

        // POST: Sector/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Accessible,Blocked,TramId,TrackId")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrackId = new SelectList(db.Tracks, "Id", "Id", sector.TrackId);
            return View(sector);
        }

        // GET: Sector/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sector sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return View(sector);
        }

        // POST: Sector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sector sector = db.Sectors.Find(id);
            db.Sectors.Remove(sector);
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
