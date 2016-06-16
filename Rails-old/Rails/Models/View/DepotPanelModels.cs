using System.Collections.Generic;
using System.Linq;


namespace Rails.Models.View
{
    public class PanelData
    {
        public virtual List<Track> Tracks { get; set; }
        public virtual List<Tram> Trams { get; set; }  

        public virtual Dictionary<int, List<Sector>> TrackSectors { get; set; }
    }



    public class DepotTrackViewModel
    {

        public Track Track
        {
            get
            {
                if (Sectors.Any())
                    return Sectors.First().Track;

                return null;
            }
        }

        public virtual ICollection<Sector> Sectors { get; set; }

    }
}