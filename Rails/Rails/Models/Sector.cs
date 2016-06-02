using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rails.Models
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Accessible { get; set; }
        public int Blocked { get; set; }

        public virtual Track Track { get; set; }
        public virtual Tram Tram { get; set; }

        public int? TramId { get; set; }
        public int? TrackId { get; set; }
    }
}