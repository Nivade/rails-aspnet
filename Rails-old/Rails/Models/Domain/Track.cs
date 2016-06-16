using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rails.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }
        public int Accessible { get; set; }
        public int InOutTrack { get; set; }


        [ForeignKey("DepotId")]
        public virtual Depot Depot { get; set; }
        
        public int? DepotId { get; set; }


    }

}