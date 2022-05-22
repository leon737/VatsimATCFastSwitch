using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VatsimConnector.Models;

namespace VatsimATCFastSwitch
{
    public partial class AtcStationButton : UserControl
    {
        private VatsimAtcStation _station;

        public event EventHandler<decimal> FrequencyChange;
        public event EventHandler<ICollection<string>> ShowAtis;

        public AtcStationButton()
        {
            InitializeComponent();
        }

        public void SetAtcStation(VatsimAtcStation station)
        {
            _station = station;
            btnSelectFrequency.Text = $"{station.Callsign} [{station.Frequency:000.000}]";
        }

        private void btnSelectFrequency_Click(object sender, EventArgs e)
        {
            if (FrequencyChange != null)
            {
                FrequencyChange(this, _station.Frequency);
            }
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            if (ShowAtis != null)
            {
                ShowAtis(this, _station.TextAtis);
            }
        }
    }
}
