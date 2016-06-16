using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{

    [Table("Track")]
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Lengte")]
        public int Length { get; set; }

        [Display(Name = "Beschikbaar")]
        public bool Accessible { get; set; }

        [Display(Name = "In en uitrij spoor")]
        public bool InOutTrack { get; set; }


        public int? DepotId { get; set; }

        [Display(Name = "Remise")]
        [ForeignKey("DepotId")]
        public virtual Depot Depot { get; set; }
    }

}