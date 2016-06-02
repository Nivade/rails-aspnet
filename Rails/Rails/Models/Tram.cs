using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models
{
    public class Tram
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }
        public string Condition { get; set; }
        public int Dirty { get; set; }
        public int Broken { get; set; }
        public int DriverQualified { get; set; }
        public int Available { get; set; }

        [ForeignKey("DepotId")]
        public virtual Depot Depot { get; set; }
        [ForeignKey("TramTypeId")]
        public virtual TramType TramType { get; set; }
        public virtual Sector Sector { get; set; }

        public int? DepotId { get; set; }
        public int? TramTypeId { get; set; }
    }
}
