using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rails.Models;

namespace Rails.Controllers
{
    public class TramController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tram
        public async Task<ActionResult> Index()
        {
            var trams = db.Trams.Include(t => t.Depot).Include(t => t.TramType);
            return View(await trams.ToListAsync());
        }

        // GET: Tram/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tram tram = await db.Trams.FindAsync(id);
            if (tram == null)
            {
                return HttpNotFound();
            }
            return View(tram);
        }

        // GET: Tram/Create
        public ActionResult Create()
        {
            ViewBag.DepotId = new SelectList(db.Depots, "Id", "Name");
            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description");
            return View();
        }

        // POST: Tram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Number,Length,Condition,Dirty,Broken,DriverQualified,Available,DepotId,TramTypeId")] Tram tram)
        {
            if (ModelState.IsValid)
            {
                db.Trams.Add(tram);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            return View(tram);
        }

        // GET: Tram/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tram tram = await db.Trams.FindAsync(id);
            if (tram == null)
            {
                return HttpNotFound();
            }


            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            return View(tram);
        }

        // POST: Tram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Number,Length,Condition,Dirty,Broken,DriverQualified,Available,DepotId,TramTypeId")] Tram tram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tram).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TramTypeId = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            return View(tram);
        }

        // GET: Tram/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tram tram = await db.Trams.FindAsync(id);
            if (tram == null)
            {
                return HttpNotFound();
            }
            return View(tram);
        }

        // POST: Tram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tram tram = await db.Trams.FindAsync(id);
            db.Trams.Remove(tram);
            await db.SaveChangesAsync();
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
