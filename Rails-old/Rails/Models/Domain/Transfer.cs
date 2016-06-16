using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models
{

    public class Transfer
    {
        
        public int Count { get; set; }

        public virtual Depot DepotFrom { get; set; }

        public virtual Depot DepotTo { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? DepotIdFrom { get; set; }

        [Key]
        [Column(Order = 2)]
        public int? DepotIdTo { get; set; }
    }

}