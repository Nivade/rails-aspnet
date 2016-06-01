using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models
{
    [Table("FUNCTIE", Schema = "DBI346087")]
    public class Functie
    {
        public int ID { get; set; }

        public string Naam { get; set; }
    }
}
