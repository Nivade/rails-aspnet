using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{
    [Table("TramMaintenance")]
    public class TramMaintenance
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        
        public DateTime? QueuedSince { get; set; }

        public string TypeOfMaintenance { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int? TramId { get; set; }

        [ForeignKey("TramId")]
        public virtual Tram Tram { get; set; }

    }

}