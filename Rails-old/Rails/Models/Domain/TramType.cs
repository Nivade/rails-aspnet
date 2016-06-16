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

}
