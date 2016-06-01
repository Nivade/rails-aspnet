using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Rails.Models;


namespace Rails.Controllers
{
    public class TramController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = ("Wagenparkbeheerder, Beheerder"))]
        // GET: Tram
        public ActionResult List()
        {
            return View(db.Trams.ToList());
        }


        // GET: Tram/Details/5
        public ActionResult Details(int id)
        {
            Tram tram = db.Trams.Find(id);
            if (tram == null)
                return new HttpStatusCodeResult(404);

            return View(tram);
        }

        // GET: Tram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tram/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tram/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tram/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tram/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tram/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
