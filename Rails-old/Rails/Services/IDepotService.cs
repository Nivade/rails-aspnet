using System.Collections.Generic;
using Rails.Models;
using Rails.Models.View;


namespace Rails.Services
{

    public interface IDepotService
    {

        IEnumerable<DepotTrackViewModel> TracksInDepot(int id);

        Depot WithName(string name);

    }

}