using Newtonsoft.Json;

namespace VatsimConnector.Models
{
    public class VatsimTransceiverEntry
    {
        public ulong Frequency { get; set; }

        [JsonProperty("latDeg")]
        public double Latitude { get; set; }

        [JsonProperty("lonDeg")]
        public double Longitude { get; set; }
    }
}