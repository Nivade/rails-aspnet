using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models.View
{

    public class TramMaintenanceSchedulePendingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht"), Display(Name = "Start Datum"), DataType(DataType.Date)]
        public DateTime SelectedStartDate { get; set; }


        [Required, Display(Name = "Technici")]
        public string SelectedTechnician { get; set; }

    }



    public class MaintenanceIndexViewModel
    {

    }

    public class TramMaintenancePendingViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }
    }

    public class MaintenanceScheduleViewModel
    {

    }

    public class MaintenanceCompleteViewModel
    {

    }

}
