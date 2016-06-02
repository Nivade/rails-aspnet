using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rails.Models
{
    public class Track
    {

        public int Id { get; set; }
        public int DepotId { get; set; }
        public virtual Depot Depot { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }
        public int Accessible { get; set; }
        public int InOutTrack { get; set; }


        public ICollection<Sector> Sectors { get; set; }

    }
}