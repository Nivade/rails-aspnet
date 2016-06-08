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
        public string Name { get; set; }

        [Display(Name = "Yearly Full Maintenance Routines")]
        public int FullMaintenanceRoutines { get; set; }

        [Display(Name = "Yearly Quick Maintenance Routines")]
        public int QuickMaintenanceRoutines { get; set; }

        [Display(Name = "Yearly Full Cleaning Routines")]
        public int FullCleanRoutines { get; set; }

        [Display(Name = "Yearly Quick Cleaning Routines")]
        public int QuickCleanRoutines { get; set; }
    }



    public class DepotViewModel
    {

        public Depot Depot { get; set; }

    }
}
