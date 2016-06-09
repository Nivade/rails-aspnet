using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models.View
{
    public class SectorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nummer")]
        public int Number { get; set; }

        [Display(Name = "Geblokkeerd")]
        public bool Blocked { get; set; }

        [Display(Name = "Toegankelijk")]
        public bool Accessible { get; set; }


        /* [Display(Name = "Geblokkeerd")]
         public bool Blocked
         {
             get { return Convert.ToBoolean(Model.Blocked); }
             set { Model.Blocked = Convert.ToInt32(value); }
         }

         [Display(Name = "Toegankelijk")]
         public bool Accessible
         {
             get { return Convert.ToBoolean(Model.Accessible); }
             set { Model.Accessible = Convert.ToInt32(value); }
         }
         */

        [Display(Name = "Tram")]
        public int? TramId { get; set; }

        [Display(Name = "Spoor")]
        public int? TrackId { get; set; }

    }



    public class SectorOccupyViewModel
    {

        

    }
}
