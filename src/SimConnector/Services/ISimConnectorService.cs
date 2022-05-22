using SimConnector.Models;
using System;

namespace SimConnector.Services
{
    public interface ISimConnectorService : IDisposable
    {
        void Connect(IntPtr hWnd);

        bool ReceiveMessage(int msg);

        void UpdateAircraftState();

        void SetCom1Freq(decimal frequency);

        event EventHandler<AircraftState> AircraftStateUpdated;

        event EventHandler Connected;

        event EventHandler Disconnected;
    }
}
