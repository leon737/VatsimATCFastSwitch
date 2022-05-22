using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VatsimConnector.Models;

namespace VatsimConnector.Services
{
    public class VatsimService : IVatsimService
    {
        private const string VatsimBaseUrl = "https://data.vatsim.net/v3/";

        public async Task<ICollection<VatsimController>> GetAllControllers()
        {
            var restClient = new RestClient(VatsimBaseUrl);
            var restRequest = new RestRequest("vatsim-data.json");
            var stringResult = await restClient.GetAsync(restRequest);
            var result = JsonConvert.DeserializeObject<VatsimData>(stringResult.Content);
            return result.Controllers.Concat(result.Atis).ToList();
        }

        public async Task<ICollection<VatsimTranceiver>> GetAllTranceivers()
        {
            var restClient = new RestClient(VatsimBaseUrl);
            var restRequest = new RestRequest("transceivers-data.json");
            var stringResult = await restClient.GetAsync(restRequest);
            var result = JsonConvert.DeserializeObject<ICollection<VatsimTranceiver>>(stringResult.Content);
            return result;
        }

        public ICollection<VatsimAtcStation> GetAtcStations(ICollection<VatsimController> controllers, ICollection<VatsimTranceiver> tranceivers)
        {
            var result = controllers.Select(controller =>
            {
                var transceiver = FindTransceiver(controller.Callsign, tranceivers);
                return new VatsimAtcStation
                {
                    Callsign = controller.Callsign,
                    Frequency = ConvertFrequency(transceiver?.Frequency ?? GetFrequencyULong(controller.Frequency)),
                    Latitude = transceiver?.Latitude ?? 0.0,
                    Longitude = transceiver?.Longitude ?? 0.0,
                    TextAtis = controller.TextAtis,
                    AtcType = GetAtcType(controller.Callsign),
                    VisualRange = SetVisualRange(controller.VisualRange, GetAtcType(controller.Callsign))
                };
            }).ToList();
            return result;
        }

        private double SetVisualRange(uint visualRange, AtcType atcType)
        {
            if (visualRange > 0)
            {
                return visualRange;
            }
            switch (atcType)
            {
                case AtcType.Atis:
                    return 150;
                case AtcType.Delivery:
                case AtcType.Ground:
                    return 10;
                case AtcType.Tower:
                    return 20;
                case AtcType.Departure:
                case AtcType.Approach:
                    return 100;
                case AtcType.Radar:
                    return 500;
                case AtcType.Unknown:
                default:
                    return 5;                
            }
        }

        private ulong GetFrequencyULong(string frequency)
        {
            if (string.IsNullOrWhiteSpace(frequency))
            {
                return 0;
            }

            var dFreq = double.Parse(frequency, CultureInfo.InvariantCulture);
            return (ulong)(dFreq * 1e6);
        }

        private AtcType GetAtcType(string callsign)
        {
            switch(callsign.Split('_').Last())
            {
                case "CTR":
                    return AtcType.Radar;
                case "DEL":
                    return AtcType.Delivery;
                case "GND":
                    return AtcType.Ground;
                case "DEP":
                    return AtcType.Departure;
                case "APP":
                    return AtcType.Approach;
                case "TWR":
                    return AtcType.Tower;
                case "ATIS":
                    return AtcType.Atis;
                default:
                    return AtcType.Unknown;
            }
        }

        private decimal ConvertFrequency(ulong frequency)
        {
            return frequency / (decimal)1e6;
        }

        private VatsimTransceiverEntry FindTransceiver(string callsign, ICollection<VatsimTranceiver> tranceivers)
        {
            var filteredTransceivers = tranceivers.Where(t => t.Callsign == callsign).ToList();
            return filteredTransceivers.FirstOrDefault()?.Transceivers.FirstOrDefault();
        }
    }
}
