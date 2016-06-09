using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rails.Models
{
    public class PanelData
    {
        public virtual List<Track> Tracks { get; set; }
        public virtual List<Tram> Trams { get; set; }  

        public virtual Dictionary<int, List<Sector>> TrackSectors { get; set; }
    }
}