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
        public int FullMaintenanceRoutines { get; set; }
        public int QuickMaintenanceRoutines { get; set; }
        public int FullCleanRoutines { get; set; }
        public int QuickCleanRoutines { get; set; }
    }
}
