using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Rails.Models.View
{
    public class TramTransferViewModel
    {
        public int? TramId { get; set; }
        public int? SectorId { get; set; }

        public virtual ICollection<Tram> Trams { get; set; }
    }

    public class TramSettingsViewModel
    {
        public int Id { get; set; }

        
        [Display(Name = "Nummer")]
        [Range(1, int.MaxValue, ErrorMessage = "Nummer kan niet lager zijn dan {1}")]
        public int Number { get; set; }

        [Display(Name = "Lengte")]
        [Range(1, 4, ErrorMessage = "Lengte moet tussen {1} en {2}")]
        public int Length { get; set; }

        [Display(Name = "Status")]
        public string Condition { get; set; }

        [Required]
        [Display(Name = "Vervuild")]
        public bool Dirty { get; set; }

        [Required]
        [Display(Name = "Defect")]
        public bool Broken { get; set; }

        [Required]
        [Display(Name = "Bestuurder Geschikt")]
        public bool DriverQualified { get; set; }

        [Required]
        [Display(Name = "Beschikbaar")]
        public bool Available { get; set; }
        
        
        public int SelectedDepotId { get; set; }

        
        public int SelectedTramTypeId { get; set; }
    }

    public class TramIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Lengte")]
        public int Length { get; set; }

        [Display(Name = "Status")]
        public string Condition { get; set; }

        [Display(Name = "Vervuild")]
        public bool Dirty { get; set; }

        [Display(Name = "Defect")]
        public bool Broken { get; set; }

        [Display(Name = "Bestuurder Geschikt")]
        public bool DriverQualified { get; set; }

        [Display(Name = "Beschikbaar")]
        public bool Available { get; set; }

        [Display(Name = "Remise Standplaats")]
        public Depot Depot { get; set; }

        [Display(Name = "Soort")]
        public TramType TramType { get; set; }
    }

}