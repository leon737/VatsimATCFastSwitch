using Newtonsoft.Json;
using System.Collections.Generic;

namespace VatsimConnector.Models
{
    public class VatsimController
    {
        public string Callsign { get; set; }

        public string Frequency { get; set; }

        [JsonProperty("visual_range")]
        public uint VisualRange { get; set; }

        [JsonProperty("text_atis")]
        public ICollection<string> TextAtis { get; set; }
    }
}