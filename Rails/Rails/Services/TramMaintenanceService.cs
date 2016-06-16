using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rails.Data;
using Rails.Models;
using Rails.Models.Domain;


namespace Rails.Services
{

    public class TramMaintenanceService : ITramMaintenanceService
    {

        RailsDbContext context = new RailsDbContext();



        public TramMaintenance ByNumber(int number)
        {
            return context.TramMaintenances.FirstOrDefault(x => x.Tram.Number == number);
        }

        public IEnumerable<TramMaintenance> GetQueued()
        {
            var trams = context.TramMaintenances.Where(tm => tm.QueuedSince != null).ToList();

            return trams;
        }

        

        public IEnumerable<TramMaintenance> GetBusy()
        {
            var trams = context.TramMaintenances.Where(tm => tm.Start != null && tm.End == null).ToList();

            return trams;
        }



        public IEnumerable<TramMaintenance> GetFinished()
        {
            var trams = context.TramMaintenances.Where(tm => tm.End != null).ToList();

            return trams;
        } 



        public bool Enqueue(int id)
        {
            var tram = context.Trams.Find(id);
            if (tram == null)
                return false;

            // Is already queued?
            if (context.TramMaintenances.Any(tm => tm.TramId == tram.Id && tm.QueuedSince != null))
                return false;

            tram.Dirty = true;
            tram.Available = false;

            TramMaintenance tramMaintenance = new TramMaintenance
            {
                QueuedSince = DateTime.Now,
                TramId = tram.Id,
                TypeOfMaintenance = "Cleaning"
            };

            context.TramMaintenances.Add(tramMaintenance);
            context.Entry(tram).State = EntityState.Modified;
            context.SaveChanges();

            return true;
        }



        public bool Start(int number, string userId)
        {
            TramMaintenance tm = ByNumber(number);

            if (tm == null)
                return false;

            tm.Start = DateTime.Now;
            tm.UserId = userId;
            tm.QueuedSince = null;
            context.Entry(tm).State = EntityState.Modified;
            context.SaveChanges();
            return true;

        }



        public bool Finish(int number)
        {
            TramMaintenance tm = ByNumber(number);
            Tram tram = tm.Tram;

            if (tm == null)
                return false;
            
            tm.End = DateTime.Now;
            tram.Dirty = false;

            if (!tram.Broken)
                tram.Available = true;

            context.Entry(tm).State = EntityState.Modified;
            context.Entry(tram).State = EntityState.Modified;

            context.SaveChanges();

            return true;
        }

    }

}