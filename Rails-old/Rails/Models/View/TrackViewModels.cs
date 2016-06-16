using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models.View
{

    public class SectorOptionsViewModel
    {

        public int Id { get; set; }


        public ICollection<Sector> Sectors { get; set; }

    }
    public class TrackIndexViewModel
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

    public class TrackSectorViewModel
    {

        public TrackIndexViewModel Track { get; set; }

        public IEnumerable<SectorViewModel> Sectors { get; set; }

    }
    
}
