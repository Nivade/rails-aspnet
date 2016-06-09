using System.ComponentModel.DataAnnotations;


namespace Rails.Models
{

    public class TramViewModel
    {
        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Lengte")]
        public int Length { get; set; }

        [Display(Name = "Status")]
        public string Condition { get; set; }

        [Display(Name = "Vervuild")]
        public int Dirty { get; set; }

        [Display(Name = "Defect")]
        public int Broken { get; set; }

        [Display(Name = "Bestuurder Geschikt")]
        public int DriverQualified { get; set; }

        [Display(Name = "Beschikbaar")]
        public int Available { get; set; }

        [Display(Name = "Remise Standplaats")]
        public Depot Depot { get; set; }

        [Display(Name = "Soort")]
        public TramType TramType { get; set; }
    }

}