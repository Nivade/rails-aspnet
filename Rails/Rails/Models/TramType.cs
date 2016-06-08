using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models
{
    public class TramType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tram> Trams { get; set; } 
    }



    public class TramRoute
    {

        [Key]
        public int Id { get; set; }

        public virtual Tram Tram { get; set; }
        public virtual Route Route { get; set; }

        public int Bound { get; set; }

        public int? TramId { get; set; }
        public int? RouteId { get; set; }
    }
}
