using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Rails.Areas.Remise.Models;
using Rails.Data;
using Rails.Models.Domain;
using Rails.Services;


namespace Rails.Areas.Remise.Controllers
{
    [Authorize(Roles = "Beheerder, Wagenparkbeheerder")]
    public class HomeController : Controller
    {
        private RailsDbContext context = new RailsDbContext();

        ISectorService sectorService = new SectorService();
        ITramMaintenanceService maintenanceService = new TramMaintenanceService();

        // GET: Remise/Home
        public ActionResult Index()
        {
            return View();
        }



        public PartialViewResult Tracks()
        {
            var tracks = context.Tracks.ToList();

            var trackModels = Mapper.Map<List<Track>, List<RemiseTrackModel>>(tracks);

            return PartialView("_Tracks", trackModels);
        }



        public PartialViewResult Sectors(int track)
        {
            var sectors = context.Sectors.Where(s => s.Track.Number == track).ToList();

            var sectorModels = Mapper.Map<List<Sector>, List<RemiseSectorModel>>(sectors);

            // Set maintenance mode on.
            foreach (var n in sectorModels)
            {
                if (n.Tram != null)
                {
                    var maintenance = context.TramMaintenances.FirstOrDefault(x => x.Tram.Id == n.Tram.Id);
                    if (maintenance != null)
                    {
                        if ((maintenance.QueuedSince != null || maintenance.Start != null) && maintenance.End == null)
                        {
                            n.TramInCleaning = true;
                        }
                    }
                }
            }

            ViewData["Track"] = track;

            return PartialView("_TrackSectors", sectorModels);
        }



        public ActionResult Block(int number)
        {
            sectorService.Block(number);

            return RedirectToAction("Index");
        }

        public ActionResult Unblock(int number)
        {
            sectorService.Unblock(number);

            return RedirectToAction("Index");
        }



        public PartialViewResult Placement(int sector)
        {
            ViewBag.Trams = context.Trams.ToList();

            RemiseTramPlacementModel model = new RemiseTramPlacementModel
            {
                SectorNumber = sector
            };

            return PartialView("_Placement", model);
        }

        [HttpPost]
        public ActionResult Placement(RemiseTramPlacementModel model)
        {
            Sector sector = context.Sectors.FirstOrDefault(x => x.Number == model.SectorNumber);
            if (sector == null)
                return HttpNotFound();

            Tram tram = context.Trams.FirstOrDefault(x => x.Number == model.TramNumber);
            if (tram == null)
                return HttpNotFound();

            foreach (var s in context.Sectors.ToList())
            {
                if (s.TramId != tram.Id)
                    continue;

                s.TramId = null;
                context.Entry(s).State = EntityState.Modified;
            }

            sector.TramId = tram.Id;

            context.Entry(sector).State = EntityState.Modified;

            context.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult ToClean(int tram)
        {
            maintenanceService.Enqueue(tram);

            return RedirectToAction("Index");
        }
    }
}