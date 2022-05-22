using System.Collections.Generic;
using System.Threading.Tasks;
using VatsimConnector.Models;

namespace VatsimConnector.Services
{
    public interface IAtcStationService
    {
        ICollection<VatsimAtcStation> GetVisibleAtcStations(double aircraftLatitude, double aircraftLongitude);

        Task Refresh();
    }
}
