using System.Collections.Generic;

namespace VatsimConnector.Models
{
    public class VatsimTranceiver
    {
        public string Callsign { get; set; }

        public ICollection<VatsimTransceiverEntry> Transceivers { get; set; }

    }
}