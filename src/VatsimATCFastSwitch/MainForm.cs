using SimConnector.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VatsimConnector.Models;
using VatsimConnector.Services;

namespace VatsimATCFastSwitch
{
    public partial class MainForm : Form
    {
        private ISimConnectorService _simConnectorService;
        private readonly IAtcStationService _atcStationService;

        private double _aircraftLatitude;
        private double _aircraftLongitude;
        private ICollection<VatsimAtcStation> _atcStations = new List<VatsimAtcStation>();
        private bool coreConnected = false;
        private bool connected = false;
        private const string TitlePrefix = "Vatsim ATC FastSwitch";
        private string errorSimulator = "";
        private string errorVatsim = "";

        public MainForm(ISimConnectorService simConnectorService, IAtcStationService atcStationService)
        {
            InitializeComponent();
            _simConnectorService = simConnectorService;
            _atcStationService = atcStationService;
            _simConnectorService.AircraftStateUpdated += _simConnectorService_AircraftStateUpdated;
            _simConnectorService.Connected += _simConnectorService_Connected;
            _simConnectorService.Disconnected += _simConnectorService_Disconnected;

        }

        private void _simConnectorService_AircraftStateUpdated(object sender, SimConnector.Models.AircraftState e)
        {
            _aircraftLatitude = e.Latitude;
            _aircraftLongitude = e.Longitude;
        }

        protected override void DefWndProc(ref Message m)
        {
            if (_simConnectorService == null || !_simConnectorService.ReceiveMessage(m.Msg))
            {
                base.DefWndProc(ref m);
            }
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblAtis.Text = "";

            ConnectToSim();

            timerAircraft_Tick(this, EventArgs.Empty);
            timerStations_Tick(this, EventArgs.Empty);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_simConnectorService != null)
            {
                _simConnectorService.AircraftStateUpdated -= _simConnectorService_AircraftStateUpdated;
                _simConnectorService.Connected -= _simConnectorService_Connected;
                _simConnectorService.Disconnected -= _simConnectorService_Disconnected;
                _simConnectorService.Dispose();
                coreConnected = false;
                _simConnectorService = null;
            }
            base.OnFormClosing(e);
        }

        private void _simConnectorService_Connected(object sender, EventArgs e)
        {
            connected = true;
            Text = $"{TitlePrefix} CONNECTED";
        }
        private void _simConnectorService_Disconnected(object sender, EventArgs e)
        {
            connected = false;
            Text = $"{TitlePrefix}";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await UpdateStations();
        }

        private async void timerStations_Tick(object sender, EventArgs e)
        {
            await UpdateStations();
        }

        private async Task UpdateStations()
        {
            try
            {
                errorVatsim = "";
                await _atcStationService.Refresh();
                _atcStations = _atcStationService.GetVisibleAtcStations(_aircraftLatitude, _aircraftLongitude);
                UpdateButtons();
            }
            catch (Exception ex)
            {
                errorVatsim = "Network error";
            }
            SetLabelError();
        }

        private void UpdateButtons()
        {
            foreach (AtcStationButton atcStationButton in flowButtons.Controls)
            {
                atcStationButton.FrequencyChange -= AtcStationButton_FrequencyChange;
                atcStationButton.ShowAtis -= AtcStationButton_ShowAtis;
                atcStationButton.Dispose();
            }
            flowButtons.Controls.Clear();
            foreach (var atcStation in _atcStations)
            {
                var atcStationButton = new AtcStationButton();
                atcStationButton.SetAtcStation(atcStation);
                atcStationButton.FrequencyChange += AtcStationButton_FrequencyChange;
                atcStationButton.ShowAtis += AtcStationButton_ShowAtis;
                flowButtons.Controls.Add(atcStationButton);
            }
        }

        private void AtcStationButton_ShowAtis(object sender, ICollection<string> e)
        {
            if (e == null)
            {
                lblAtis.Text = "";
            }
            else
            {
                var text = string.Join(" ", e);
                lblAtis.Text = text;
            }
        }

        private void AtcStationButton_FrequencyChange(object sender, decimal e)
        {
            if (coreConnected && connected)
            {
                _simConnectorService.SetCom1Freq(e);
            }
        }

        private void btnTopmost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void timerAircraft_Tick(object sender, EventArgs e)
        {
            if (_simConnectorService == null)
            {
                return;
            }
            if (!coreConnected)
            {
                ConnectToSim();
                coreConnected = true;
                if (connected)
                {
                    _simConnectorService.UpdateAircraftState();
                }
            }
        }

        private void ConnectToSim()
        {
            Text = $"{TitlePrefix}";
            if (!coreConnected)
            {
                errorSimulator = "";
                try
                {
                    _simConnectorService.Connect(Handle);
                    coreConnected = true;
                }
                catch (Exception ex)
                {
                    errorSimulator = "Cannot connect to simulator";
                }
                SetLabelError();
            }
        }

        private void SetLabelError()
        {
            var error = errorSimulator + "\r\n" + errorVatsim;
            lblError.Text = error;
        }
    }
    
}
