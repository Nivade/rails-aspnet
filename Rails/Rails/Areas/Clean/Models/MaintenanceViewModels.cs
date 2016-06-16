using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rails.Models;


namespace Rails.Areas.Clean.Models
{

    public class CleanTramViewModel
    {
        [Display(Name = "Tram")]
        public int Number { get; set; }

        [Display(Name = "Soort")]
        public string Description { get; set; }



        public CleanTramViewModel(int number, string description)
        {
            Number = number;
            Description = description;
        }

    }



    public class CleanIndexViewModel
    {
        public CleanTramViewModel Tram { get; set; }

        public IEnumerable<CleanQueueViewModel> Queued { get; set; }


        public IEnumerable<CleanBusyViewModel> Busy { get; set; }

    }

    public class CleanQueueViewModel
    {
        [Display(Name = "Tram")]
        public int Number { get; set; }

        [Display(Name = "Soort")]
        public string Description { get; set; }

        [Display(Name = "Wachtlijst sinds")]
        public DateTime QueuedSince { get; set; }

        public DateTime Deadline { get; set; }
    }



    public class CleanBusyViewModel
    {
        [Display(Name = "Tram")]
        public int Number { get; set; }

        [Display(Name = "Soort")]
        public string Description { get; set; }

        [Display(Name = "Schoonmaker")]
        public string Cleaner { get; set; }

        [Display(Name = "Begonnen op")]
        public DateTime Start { get; set; }

    }

    public class CleanFinishedViewModel
    {
        [Display(Name = "Tram")]
        public int Number { get; set; }

        [Display(Name = "Soort")]
        public string Description { get; set; }

        [Display(Name = "Schoonmaker")]
        public string Cleaner { get; set; }

        [Display(Name = "Begonnen op")]
        public DateTime Start { get; set; }

        [Display(Name = "Afgerond")]
        public DateTime End { get; set; }

    }
}
