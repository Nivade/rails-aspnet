using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{

    [Table("TramRoute")]
    public class TramRoute
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Gebonden aan route")]
        public bool Bound { get; set; }

        public int? TramId { get; set; }

        public int? RouteId { get; set; }

        [Display(Name = "Tram")]
        public virtual Tram Tram { get; set; }

        [Display(Name = "Route")]
        public virtual Route Route { get; set; }

    }

}