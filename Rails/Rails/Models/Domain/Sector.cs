using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{

    [Table("Sector")]
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public bool Accessible { get; set; }

        public bool Blocked { get; set; }

        public int? TrackId { get; set; }

        [ForeignKey("TrackId")]
        public virtual Track Track { get; set; }

        public int? TramId { get; set; }

        public virtual Tram Tram { get; set; }
    }


    [Table("Connection")]
    public class Connection
    {
        [Key]
        public int Id { get; set; }


        public int? SectorFromId { get; set; }

        [ForeignKey("SectorFromId")]
        public virtual Sector SectorFrom { get; set; }

        public int? SectorToId { get; set; }

        [ForeignKey("SectorToId")]
        public virtual Sector SectorTo { get; set; }

    }

}