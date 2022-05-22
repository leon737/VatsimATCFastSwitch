using System.Collections.Generic;

namespace VatsimConnector.Models
{
    public class VatsimAtcStation
    {
        public string Callsign { get; set; }

        public decimal Frequency { get; set; }  

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<string> TextAtis { get; set; }

        public AtcType AtcType { get; set; }

        public double VisualRange { get; set; } 

        public override string ToString()
        {
            return $"{Callsign} {Frequency}";
        }
    }
}