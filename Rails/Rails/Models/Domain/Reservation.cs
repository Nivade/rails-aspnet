using System.ComponentModel.DataAnnotations;


namespace Rails.Models
{

    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Tram Tram { get; set; }
        public virtual Track Track { get; set; }

        public int? TramId { get; set; }
        public int? TrackId { get; set; }
    }

}