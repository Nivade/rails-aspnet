using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{
    [Table("Tram")]
    public class Tram
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Lengte")]
        public int Length { get; set; }

        [Display(Name = "Conditie")]
        public string Condition { get; set; }

        [Display(Name = "Vies")]
        public bool Dirty { get; set; }

        [Display(Name = "Defect")]
        public bool Broken { get; set; }

        [Display(Name = "Bestuurder Geschikt")]
        public bool DriverQualified { get; set; }

        [Display(Name = "Beschikbaar")]
        public bool Available { get; set; }


        public int? TramTypeId { get; set; }

        [ForeignKey("TramTypeId")]
        public virtual TramType TramType { get; set; }
    }

}
