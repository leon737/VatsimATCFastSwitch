namespace VatsimConnector.Services
{
    public interface IDistanceCalculator
    {
        double Calculate(double aircraftLatitude, double aircraftLongitude, double atcStationLatitude, double atcStationLongitude);
    }
}
