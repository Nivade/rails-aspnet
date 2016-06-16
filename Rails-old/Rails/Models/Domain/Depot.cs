using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models
{
    public class Depot
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Grote service beurten per jaar")]
        public int FullMaintenanceRoutines { get; set; }

        [Display(Name = "Kleine service beurten per jaar")]
        public int QuickMaintenanceRoutines { get; set; }

        [Display(Name = "Grote schoonmaak beurten per jaar")]
        public int FullCleanRoutines { get; set; }

        [Display(Name = "Kleine schoonmaak beurten per jaar")]
        public int QuickCleanRoutines { get; set; }
    }



    public class DepotViewModel
    {

        public Depot Depot { get; set; }

    }
}
