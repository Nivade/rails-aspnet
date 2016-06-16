using System.ComponentModel.DataAnnotations;


namespace Rails.Models
{

    public class TramRoute
    {

        [Key]
        public int Id { get; set; }

        public virtual Tram Tram { get; set; }
        public virtual Route Route { get; set; }

        public int Bound { get; set; }

        public int? TramId { get; set; }
        public int? RouteId { get; set; }
    }

}