using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using Rails.Models;
using Rails.Models.View;


namespace Rails.Controllers
{

    

    public class MaintenanceController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maintenance
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Pending()
        {
            List<TramMaintenance> trams = db.TramMaintenance.ToList();

            List<TramMaintenancePendingViewModel> pending = Mapper.Map<List<TramMaintenance>, List<TramMaintenancePendingViewModel>>(trams);

            return PartialView("_PendingPartial", pending);

        }



        public PartialViewResult SchedulePendingPartial(int? id)
        {

            IdentityRole role = db.Roles.FirstOrDefault(x => x.Name == "Technicus");
            ICollection<IdentityUserRole> userTechnicians = role.Users;
            IEnumerable<ApplicationUser> technicians = db.Users.Where(u => userTechnicians.Select(x => x.UserId).Contains(u.Id));

            ViewData["Technicians"] = db.Users.ToList();

            TramMaintenance tram = db.TramMaintenance.Find(id);

            TramMaintenanceSchedulePendingViewModel scheduleModel = Mapper.Map<TramMaintenance, TramMaintenanceSchedulePendingViewModel>(tram);

            return PartialView("_SchedulePendingPartial", scheduleModel);
        }

        public ActionResult Schedule(MaintenanceScheduleViewModel model)
        {

            return View();
        }



        public ActionResult Complete(MaintenanceCompleteViewModel model)
        {

            return View();
        }
    }
}