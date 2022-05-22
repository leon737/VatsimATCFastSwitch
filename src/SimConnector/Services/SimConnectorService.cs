using Microsoft.FlightSimulator.SimConnect;
using SimConnector.Models;
using System;

namespace SimConnector.Services
{
    public class SimConnectorService : ISimConnectorService
    {
        SimConnect simconnect = null;
        const int WM_USER_SIMCONNECT = 0x0402;

        private AircraftState _aircraftState = new AircraftState();
        public event EventHandler<AircraftState> AircraftStateUpdated;
        public event EventHandler Connected;
        public event EventHandler Disconnected;

        public void Connect(IntPtr hWnd)
        {
            simconnect = new SimConnect("Managed Data Request", hWnd, WM_USER_SIMCONNECT, null, 0);

            simconnect.OnRecvSimobjectDataBytype += OnGetDataByte;
            simconnect.OnRecvOpen += Simconnect_OnRecvOpen;
            simconnect.OnRecvQuit += Simconnect_OnRecvQuit;

            simconnect.AddToDataDefinition(DEFINITIONS.LOCATION, "Plane Latitude", "degrees latitude", SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DEFINITIONS.LOCATION, "Plane Longitude", "degrees longitude", SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DEFINITIONS.LOCATION, "COM Active Frequency:1", "Mhz", SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);

            simconnect.RegisterDataDefineStruct<LocationStruct>(DEFINITIONS.LOCATION);

            simconnect.MapClientEventToSimEvent(EVENTS.COM1Swap, "COM_STBY_RADIO_SWAP");
            simconnect.MapClientEventToSimEvent(EVENTS.COM1Set, "COM_STBY_RADIO_SET_HZ");

        }

        private void Simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            if (Disconnected != null)
            {
                Disconnected(this, EventArgs.Empty);
            }
        }

        private void Simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            if (Connected != null)
            {
                Connected(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            if (simconnect != null)
            {
                simconnect.Dispose();
                simconnect = null;
            }
        }

        public void UpdateAircraftState()
        {
            simconnect.RequestDataOnSimObjectType(DATA_REQUESTS.REQUEST_1, DEFINITIONS.LOCATION, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        public void SetCom1Freq(decimal frequency)
        {
            simconnect.TransmitClientEvent((uint)DEFINITIONS.COMFreq, EVENTS.COM1Set, (uint)(frequency * 1000 * 1000), DATA_REQUESTS.REQUEST_1, SIMCONNECT_EVENT_FLAG.DEFAULT);
            simconnect.TransmitClientEvent((uint)DEFINITIONS.COMFreq, EVENTS.COM1Swap, 0, DATA_REQUESTS.REQUEST_1, SIMCONNECT_EVENT_FLAG.DEFAULT);
        }

        public bool ReceiveMessage(int msg)
        {
            if (msg == 0x402)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
                return true;
            }
            return false;
        }

        void OnGetDataByte(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            switch ((DEFINITIONS)data.dwDefineID)
            {
                case DEFINITIONS.LOCATION:
                    var location = (LocationStruct)data.dwData[0];
                    _aircraftState.Latitude = location.Plane_Latitude;
                    _aircraftState.Longitude = location.Plane_Longitude;
                    _aircraftState.Com1Frequency = (decimal)location.Com1Freq;
                    if (AircraftStateUpdated != null)
                    {
                        AircraftStateUpdated(this, _aircraftState);
                    }
                    break;
            }
        }
    }
}
