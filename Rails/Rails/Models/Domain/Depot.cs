using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rails.Models.Domain
{

    [Table("Depot")]
    public class Depot
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int FullMaintenanceRoutines { get; set; }
        public int QuickMaintenanceRoutines { get; set; }
        public int FullCleanRoutines { get; set; }
        public int QuickCleanRoutines { get; set; }
    }

}