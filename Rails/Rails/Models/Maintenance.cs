namespace Rails.Models
{

    public class Maintenance
    {
        public int FullMaintenanceRoutines { get; set; }
        public int QuickMaintenanceRoutines { get; set; }
        public int FullCleaningRoutines { get; set; }
        public int QuickCleaningRoutines { get; set; }
    }

}