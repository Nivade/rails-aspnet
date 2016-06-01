using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rails.Models;

namespace Rails.Controllers
{
    public class RolePermissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RolePermission
        public ActionResult Index()
        {
            var rolePermissions = db.RolePermissions.Include(r => r.Permission);
            return View(rolePermissions.ToList());
        }

        // GET: RolePermission/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = db.RolePermissions.Find(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // GET: RolePermission/Create
        public ActionResult Create()
        {
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Description");
            return View();
        }

        // POST: RolePermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,PermissionId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                db.RolePermissions.Add(rolePermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Description", rolePermission.PermissionId);
            return View(rolePermission);
        }

        // GET: RolePermission/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = db.RolePermissions.Find(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Description", rolePermission.PermissionId);
            return View(rolePermission);
        }

        // POST: RolePermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,PermissionId")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolePermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Description", rolePermission.PermissionId);
            return View(rolePermission);
        }

        // GET: RolePermission/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermission rolePermission = db.RolePermissions.Find(id);
            if (rolePermission == null)
            {
                return HttpNotFound();
            }
            return View(rolePermission);
        }

        // POST: RolePermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RolePermission rolePermission = db.RolePermissions.Find(id);
            db.RolePermissions.Remove(rolePermission);
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
