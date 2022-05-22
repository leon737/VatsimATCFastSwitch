using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatsimConnector.Models;

namespace VatsimConnector.Services
{
    public class AtcStationService : IAtcStationService
    {
        private readonly IVatsimService _vatsimService;
        private readonly IDistanceCalculator _distanceCalculator;

        private ICollection<VatsimAtcStation> _allStations = new List<VatsimAtcStation>();

        public AtcStationService(IVatsimService vatsimService, IDistanceCalculator distanceCalculator)
        {
            _vatsimService = vatsimService;
            _distanceCalculator = distanceCalculator;
        }

        public ICollection<VatsimAtcStation> GetVisibleAtcStations(double aircraftLatitude, double aircraftLongitude)
        {
            var result = _allStations
                .Where(station => _distanceCalculator
                    .Calculate(aircraftLatitude, aircraftLongitude, station.Latitude, station.Longitude) <= station.VisualRange
                    && !station.Callsign.Contains("OBS") && station.Frequency < 140.0m)
                .ToList();
            result.Add(GetUnicomStation());
            return result.OrderBy(station => station.AtcType).ToList();
        }

        private VatsimAtcStation GetUnicomStation()
        {
            var result = new VatsimAtcStation
            {
                AtcType = AtcType.Unknown,
                Callsign = "UNICOM",
                Frequency = 122.8m
            };
            return result;
        }

        public async Task Refresh()
        {
            var controllers = await _vatsimService.GetAllControllers();
            var transceivers = await _vatsimService.GetAllTranceivers();
            _allStations = _vatsimService.GetAtcStations(controllers, transceivers);
        }
    }
}
