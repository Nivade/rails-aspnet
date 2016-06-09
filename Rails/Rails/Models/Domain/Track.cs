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
        public int Number { get; set; }
        public int Length { get; set; }
        public int Accessible { get; set; }
        public int InOutTrack { get; set; }


        [ForeignKey("DepotId")]
        public virtual Depot Depot { get; set; }
        
        public int? DepotId { get; set; }


    }



    public class TrackViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Spoor")]
        public int Number { get; set; }


        [Required]
        [Display(Name = "Lengte")]
        public int Length { get; set; }


        [Required]
        [Display(Name = "Beschikbaar")]
        public bool Accessible { get; set; }


        [Required]
        [Display(Name = "In-uitrij Spoor")]
        public bool InOutTrack { get; set; }


        public Depot Depot { get; set; }

    }



    public class TrackSectorViewModel
    {

        public TrackViewModel Track { get; set; }

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