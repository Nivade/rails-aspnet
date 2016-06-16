using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rails.Models;
using Rails.Models.Domain;


namespace Rails.Services
{
    public interface ITramMaintenanceService
    {

        IEnumerable<TramMaintenance> GetQueued();

        IEnumerable<TramMaintenance> GetBusy();
        IEnumerable<TramMaintenance> GetFinished();

        bool Enqueue(int id);

        bool Start(int id, string userId);

        bool Finish(int id);

    }

}
