using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rails.Models.Builders
{
    
    public class TramViewModelBuilder
    {

        private readonly ApplicationDbContext db;



        public TramViewModelBuilder(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
