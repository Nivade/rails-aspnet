using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models
{
    public class Connection
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SectorIdFrom")]
        public virtual Sector From { get; set; }

        [ForeignKey("SectorIdTo")]
        public virtual Sector To { get; set; }

        public int? SectorIdFrom { get; set; }
        public int SectorIdTo { get; set; }
    }

}
