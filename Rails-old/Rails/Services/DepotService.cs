using System.Collections.Generic;
using System.Linq;
using Rails.Models;
using Rails.Models.View;


namespace Rails.Services
{

    public class DepotService : IDepotService
    {

        public  ApplicationDbContext Context { get; private set; }



        public DepotService(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<DepotTrackViewModel> TracksInDepot(int id)
        {
            List<Track> tracksInDepot = Context.Tracks.Where(x => x.DepotId == id).ToList();
            List<DepotTrackViewModel> depotTrackViewModels = new List<DepotTrackViewModel>();
            foreach (Track t in tracksInDepot)
            {
                DepotTrackViewModel d = new DepotTrackViewModel
                {
                    Sectors = Context.Sectors.Where(s => s.TrackId == t.Id).ToList()
                };

                depotTrackViewModels.Add(d);
            }

            return depotTrackViewModels;
        }



        public Depot WithName(string name)
        {
            return Context.Depots.FirstOrDefault(depot => depot.Name.Contains(name));
        }

    }

}