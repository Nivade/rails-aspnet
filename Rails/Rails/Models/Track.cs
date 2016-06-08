using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rails.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Lengte")]
        public int Length { get; set; }

        [Display(Name = "Beschikbaar")]
        public int Accessible { get; set; }

        [Display(Name = "In-uitrij Spoor")]
        public int InOutTrack { get; set; }

        [Display(Name = "Locatie")]
        [ForeignKey("DepotId")]
        public virtual Depot Depot { get; set; }


        [Display(Name = "Locatie")]
        public int? DepotId { get; set; }


        [Display(Name = "Sectoren")]
        public virtual ICollection<Sector> Sectors { get; set; }

        
        

    }



    public class TrackViewModel
    {

        public Track Track { get; set; }


        [Display(Name = "Beschikbaar")]
        public bool Accessible
        {
            get { return Convert.ToBoolean(Track.Accessible); }
            set { Track.Accessible = Convert.ToInt32(value); }
        }

        [Display(Name = "In-uitrij Spoor")]
        public bool InOutTrack
        {
            get { return Convert.ToBoolean(Track.InOutTrack); }
            set { Track.InOutTrack = Convert.ToInt32(value); }
        }

        public DepotViewModel Depot { get; set; }

        public IEnumerable<SectorViewModel> Sectors { get; set; }

    }



    public class TrackEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Lengte")]
        public int Length { get; set; }

        [Required]
        [Display(Name = "Beschikbaar")]
        public bool Accessible { get; set; }

        [Required]
        [Display(Name = "In/Uitrij Spoor")]
        public bool InOutTrack { get; set; }

        [Display(Name = "Locatie")]
        public int? DepotId { get; set; }

        [Display(Name = "Sectoren")]
        public virtual ICollection<Sector> Sectors { get; set; } 

        public int TramId { get; set; }

        public ICollection<Depot> Depots { get; set; } 

        public ICollection<Tram> Trams { get; set; } 
    }
}