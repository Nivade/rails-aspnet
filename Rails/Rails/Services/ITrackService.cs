using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rails.Models;


namespace Rails.Services
{

    public interface ITrackService
    {

        

    }



    public class TrackService : ITrackService
    {

        private readonly ApplicationDbContext context;



        public TrackService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public TrackViewModel GenerateModel(int? trackId)
        {

            Track track = context.Tracks.Find(trackId);
            if (track == null)
                return null;

            Depot depot = context.Depots.Find(track.DepotId);
            if (depot == null)
                return null;

            TrackViewModel model = new TrackViewModel
            {
                Id = track.Id,
                Depot = depot
            };

            return model;
        }

        public TrackViewModel GenerateModel(Track track)
        {
            if (track == null)
                return null;

            TrackViewModel model = new TrackViewModel
            {
                Id = track.Id,
                Depot = track.Depot
            };

            return model;
        }

    }

}