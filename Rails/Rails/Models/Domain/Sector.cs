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
        public int Number { get; set; }
        public int Accessible { get; set; }
        public int Blocked { get; set; }

        
        [ForeignKey("TrackId")]
        public virtual Track Track { get; set; }


        [Display(Name = "Tram")]
        public virtual Tram Tram { get; set; }
        
        public int? TrackId { get; set; }
        public int? TramId { get; set; }
        
    }



    public class SectorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Geblokkeerd")]
        public bool Blocked { get; set; }

        [Display(Name = "Toegankelijk")]
        public bool Accessible { get; set; }


        /* [Display(Name = "Geblokkeerd")]
         public bool Blocked
         {
             get { return Convert.ToBoolean(Model.Blocked); }
             set { Model.Blocked = Convert.ToInt32(value); }
         }

         [Display(Name = "Toegankelijk")]
         public bool Accessible
         {
             get { return Convert.ToBoolean(Model.Accessible); }
             set { Model.Accessible = Convert.ToInt32(value); }
         }
         */

        [Display(Name = "Tram")]
        public int? TramId { get; set; }

        [Display(Name = "Spoor")]
        public int? TrackId { get; set; }

    }



    public class TramPlacementViewModel
    {
        public virtual Sector Sector { get; set; }
        public virtual Tram Tram { get; set; }
        public int? SectorId { get; set; }
        public int? TramId { get; set; }

        public virtual ICollection<Tram> Trams { get; set; } 
    }


}