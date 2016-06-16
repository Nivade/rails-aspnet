using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{

    [Table("Route")]
    public class Route
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Bestuurder mee")]
        public bool AccompaniedByDriver { get; set; }
        

    }

}