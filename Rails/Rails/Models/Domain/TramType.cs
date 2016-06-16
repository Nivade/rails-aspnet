using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{
    [Table("TramType")]
    public class TramType
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }

}