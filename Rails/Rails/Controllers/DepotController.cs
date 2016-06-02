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
    public class DepotController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Depot
        public async Task<ActionResult> Index()
        {
            return View(await db.Depots.ToListAsync());
        }

        // GET: Depot/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depot depot = await db.Depots.FindAsync(id);
            if (depot == null)
            {
                return HttpNotFound();
            }
            return View(depot);
        }

        // GET: Depot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Depot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,FullMaintenanceRoutines,QuickMaintenanceRoutines,FullCleanRoutines,QuickCleanRoutines")] Depot depot)
        {
            if (ModelState.IsValid)
            {
                db.Depots.Add(depot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(depot);
        }

        // GET: Depot/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depot depot = await db.Depots.FindAsync(id);
            if (depot == null)
            {
                return HttpNotFound();
            }
            return View(depot);
        }

        // POST: Depot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,FullMaintenanceRoutines,QuickMaintenanceRoutines,FullCleanRoutines,QuickCleanRoutines")] Depot depot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(depot);
        }

        // GET: Depot/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depot depot = await db.Depots.FindAsync(id);
            if (depot == null)
            {
                return HttpNotFound();
            }
            return View(depot);
        }

        // POST: Depot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Depot depot = await db.Depots.FindAsync(id);
            db.Depots.Remove(depot);
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
