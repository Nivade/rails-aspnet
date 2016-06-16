using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Rails.Attributes;
using Rails.Helpers;
using Rails.Models;
using Rails.Models.View;


namespace Rails.Controllers
{
    [Authorize]
    public class TramController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Tram
        public ActionResult Index()
        {
            var models = Mapper.Map<List<Tram>, List<TramIndexViewModel>>(db.Trams.ToList());
            return View(models);
        }

        
        // GET: Tram/Settings/5
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

            TramSettingsViewModel model = Mapper.Map<Tram, TramSettingsViewModel>(tram);

            ViewBag.TramTypes = new SelectList(db.TramTypes, "Id", "Description", tram.TramTypeId);
            ViewBag.Depots = new SelectList(db.Depots, "Id", "Name", tram.DepotId);

            return View(model);
        }

        // POST: Tram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeEmployment(Employment.Beheerder, Employment.WagenparkBeheerder)]
        public ActionResult Details(TramSettingsViewModel model)
        {
            Tram tram = Mapper.Map<TramSettingsViewModel, Tram>(model);

            if (ModelState.IsValid)
            {
                db.Entry(tram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TramTypes = new SelectList(db.TramTypes, "Id", "Description", model.SelectedTramTypeId);
            ViewBag.Depots = new SelectList(db.TramTypes, "Id", "Name", model.SelectedDepotId);

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeEmployment(Employment.Beheerder, Employment.WagenparkBeheerder)]
        public ActionResult Transfer(TransferViewModel model)
        {
            var tram = db.Trams.Find(model.Id);
            if (tram == null)
                return HttpNotFound("Tram id does not exist.");

            var sector = db.Sectors.Find(model.SectorId);
            if (sector == null)
                return HttpNotFound("Sector id does not exist.");

            var sectors = db.Sectors;
            foreach (var s in sectors)
            {
                if (s.TramId == tram.Id)
                {
                    s.TramId = null;
                    db.SaveChanges();
                }
            }

            sector.TramId = tram.Id;

            db.SaveChanges();

            return RedirectToAction("Index", "Track", null);
        }


        [AuthorizeEmployment(Roles = "Technicus")]
        public ActionResult Update(int? id)
        {

            return View();
        }



        public ActionResult ToHouseKeeping(int? id)
        {

            return View();
        }



        public ActionResult ToMaintenance(int? id)
        {

            return View();
        }

    }
}
