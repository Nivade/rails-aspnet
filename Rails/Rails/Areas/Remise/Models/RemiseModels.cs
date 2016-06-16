using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rails.Models.Domain;


namespace Rails.Areas.Remise.Models
{
    public class RemiseTrackModel
    {
        public int Number { get; set; }

        public int Length { get; set; }

        public bool Accessible { get; set; }

        public bool InOutTrack { get; set; }
    }



    public class RemiseSectorModel
    {
        public int TrackNumber { get; set; }

        public int SectorNumber { get; set; }

        public bool Accessible { get; set; }

        public bool Blocked { get; set; }
        
        public virtual Tram Tram { get; set; }

        public bool TramInCleaning { get; set; }

        public bool TramInRepairs { get; set; }
    }



    public class RemiseTramPlacementModel
    {

        public int? TramNumber { get; set; }

        public int SectorNumber { get; set; }

    }
}
