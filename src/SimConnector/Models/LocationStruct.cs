using System.Runtime.InteropServices;

namespace SimConnector.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    struct LocationStruct
    {
        public double Plane_Latitude;
        public double Plane_Longitude;
        public double Com1Freq;
    };
}
