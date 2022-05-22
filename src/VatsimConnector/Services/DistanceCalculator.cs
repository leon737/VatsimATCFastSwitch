using System;

namespace VatsimConnector.Services
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public double Calculate(double aircraftLatitude, double aircraftLongitude, double atcStationLatitude, double atcStationLongitude)
        {
            const double R = 6371;
            var dLat = Deg2rad(atcStationLatitude - aircraftLatitude);
            var dLon = Deg2rad(atcStationLongitude - aircraftLongitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) 
                + Math.Cos(Deg2rad(aircraftLatitude)) * Math.Cos(Deg2rad(atcStationLatitude))
                * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c * 0.5399568;
            return d;
        }

        private double Deg2rad(double value)
        {
            return value * Math.PI / 180;
        }
    }
}
