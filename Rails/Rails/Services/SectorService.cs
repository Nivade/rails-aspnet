using System;
using System.Collections.Generic;
using System.Linq;
using Rails.Models;


namespace Rails.Services
{

    public class SectorService : ISectorService
    {

        private readonly ApplicationDbContext db;



        public SectorService(ApplicationDbContext context)
        {
            db = context;
        }

        public bool Connect(int fromId, int toId)
        {
            Sector a = db.Sectors.Find(fromId);
            if (a == null)
                return false;

            Sector b = db.Sectors.Find(toId);
            if (b == null)
                return false;

            if (a.TrackId != b.TrackId)
                return false;

            Connection connection = new Connection
            {
                From = a,
                To = b
            };

            db.Connections.Add(connection);

            db.SaveChanges();

            return true;
        }



        public bool Add(int trackId)
        {
            Track track = db.Tracks.Find(trackId);
            if (track == null)
            {
                return false;
            }

            IEnumerable<Sector> sectors = db.Sectors.Where(x => x.TrackId == track.Id);

            Sector newSector = new Sector
            {
                Accessible = 1,
                Blocked = 0,
                TrackId = trackId
            };

            if (sectors.Any())
            {
                newSector.Number = sectors.Last().Number + 1;
            }
            else
            {
                Random r = new Random();
                newSector.Number = r.Next(1, 10000);
            }

            db.Sectors.Add(newSector);
            db.SaveChanges();

            return Connect(newSector.Id, sectors.Last().Id);


        }

    }

}