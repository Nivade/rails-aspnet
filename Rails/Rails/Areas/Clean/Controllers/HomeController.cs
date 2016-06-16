using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Rails.Areas.Clean.Models;
using Rails.Data;
using Rails.Models;
using Rails.Models.Domain;
using Rails.Services;


namespace Rails.Areas.Clean.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private RailsDbContext context = new RailsDbContext();
        public ITramMaintenanceService TramMaintenanceService { get; private set; } = new TramMaintenanceService();

        // GET: Clean/Home
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            bool myTasks = TramMaintenanceService.GetBusy().Any(x => x.UserId == userId);

            ViewBag.HasTasks = myTasks;

            return View();
        }



        public PartialViewResult Queued()
        {
            IEnumerable<TramMaintenance> queued = TramMaintenanceService.GetQueued();

            var queuedModels = AutoMapper.Mapper.Map<IEnumerable<TramMaintenance>, List<CleanQueueViewModel>>(queued);

            ViewData["UserIsCleaner"] = User.IsInRole("Schoonmaker");

            return PartialView("_Queued", queuedModels);
        }



        public PartialViewResult Busy()
        {
            IEnumerable<TramMaintenance> busy = TramMaintenanceService.GetBusy();

            var busyModels = AutoMapper.Mapper.Map<IEnumerable<TramMaintenance>, List<CleanBusyViewModel>>(busy);

            return PartialView("_Busy", busyModels);
        }



        public PartialViewResult MyTasks()
        {
            string userId = User.Identity.GetUserId();

            IEnumerable<TramMaintenance> myTasks = TramMaintenanceService.GetBusy().Where(x => x.UserId == userId);

            var myTaskModels = AutoMapper.Mapper.Map<IEnumerable<TramMaintenance>, List<CleanBusyViewModel>>(myTasks);

            return PartialView("_MyTasks", myTaskModels);
        }



        public PartialViewResult Finished()
        {
            var finished = TramMaintenanceService.GetFinished();

            var finishedModels = AutoMapper.Mapper.Map<IEnumerable<TramMaintenance>, List<CleanFinishedViewModel>>(finished);

            return PartialView("_Finished", finishedModels);
        }



        public ActionResult Start(int number, string userId)
        {
            TramMaintenanceService.Start(number, userId);

            return RedirectToAction("Index");
        }



        public ActionResult Finish(int number)
        {
            TramMaintenanceService.Finish(number);

            return RedirectToAction("Index");
        }
    }
}