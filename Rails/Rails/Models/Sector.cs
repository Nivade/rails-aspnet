using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rails.Models
{
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Beschikbaar")]
        public int Accessible { get; set; }

        [Display(Name = "Geblokkeerd")]
        public int Blocked { get; set; }

        
        [ForeignKey("TrackId")]
        [Display(Name = "Spoor")]
        public virtual Track Track { get; set; }


        [Display(Name = "Tram")]
        public virtual Tram Tram { get; set; }
        
        public int? TrackId { get; set; }
        public int? TramId { get; set; }
        
    }



    public class SectorViewModel
    {
        public Sector Sector { get; set; }

        public TramViewModel Tram { get; set; }


        public bool Blocked
        {
            get { return Convert.ToBoolean(Sector.Blocked); }
            set { Sector.Blocked = Convert.ToInt32(value); }
        }

    }


}