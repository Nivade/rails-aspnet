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

        /// <summary>
        /// Solidifies a connection between two seperate sectors.
        /// </summary>
        /// <param name="fromId"> Specifies the sector to connect from. </param>
        /// <param name="toId"> Specifies the sector to connect to. </param>
        /// <returns></returns>
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



        /// <summary>
        /// Adds a new sector to the specified track, and connects it to its siblings.
        /// </summary>
        /// <param name="trackId"> Specifies the track to add a new sector to. </param>
        /// <returns></returns>
        public bool Add(int trackId)
        {
            Track track = db.Tracks.Find(trackId);
            if (track == null)
                return false;


            IEnumerable<Sector> sectorsInTrack = db.Sectors.Where(x => x.TrackId == track.Id);

            Sector newSector = new Sector
            {
                Accessible = 1,
                Blocked = 0,
                TrackId = trackId
            };

            if (sectorsInTrack.Any())
            {
                newSector.Number = sectorsInTrack.Last().Number + 1;
            }
            else
            {
                Random r = new Random();
                newSector.Number = r.Next(1, 10000);
            }

            db.Sectors.Add(newSector);
            db.SaveChanges();

            return Connect(newSector.Id, sectorsInTrack.Last().Id);


        }

    }

}