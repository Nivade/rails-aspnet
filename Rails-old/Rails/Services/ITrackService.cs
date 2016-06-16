using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rails.Models;
using Rails.Models.View;


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



        public IEnumerable<DepotTrackViewModel> GetTracksInDepot(int id)
        {
            List<Track> tracksInDepot = context.Tracks.Where(x => x.DepotId == id).ToList();
            List<DepotTrackViewModel> depotTrackViewModels = new List<DepotTrackViewModel>();
            foreach (Track t in tracksInDepot)
            {
                DepotTrackViewModel d = new DepotTrackViewModel
                {
                    Sectors = context.Sectors.Where(s => s.TrackId == t.Id).ToList()
                };

                depotTrackViewModels.Add(d);
            }

            return depotTrackViewModels;
        }

    }

}