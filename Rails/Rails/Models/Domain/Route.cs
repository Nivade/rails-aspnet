using System.ComponentModel.DataAnnotations;


namespace Rails.Models
{

    public class Route
    {
        [Key]
        public int Id { get; set; }

        public virtual Depot Depot { get; set; }

        public int Number { get; set; }

        public int AccompaniedByDriver { get; set; }

        public int? DepotId { get; set; }
    }

}