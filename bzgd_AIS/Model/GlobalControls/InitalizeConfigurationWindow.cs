using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;

using bzgd_AIS.AppConfiguration;

namespace bzgd_AIS.Model.GlobalControls
{
    public partial class InitalizeConfigurationWindow : Form
    {

        public InitalizeConfigurationWindow()
        {
            InitializeComponent();
            
            this.ServerIP.Text = ConfigurationWorker.ServerIP;
            this.ServerPort.Text = ConfigurationWorker.ServerPort.ToString();
            this.HideIntoTrayChB.Checked = ConfigurationWorker.HideIntoTray;
        }

        private void SaveConfiguration_Click(object sender, EventArgs e)
        {
            IPAddress uselessIP = new IPAddress(0x000000);

            if (!IPAddress.TryParse(ServerIP.Text, out uselessIP) && (ServerIP.Text.Replace(" ", "") != "localhost"))
            {
                MessageBox.Show("Empty value of server IP. Error.");
                return;
            }

            int uselessINT;
            bool portParse = int.TryParse(ServerPort.Text, out uselessINT);

            if (!portParse)
            {
                MessageBox.Show("Empty value of server port. Error.");
                return;
            }

            try
            {
                ConfigurationWorker.ServerIP = this.ServerIP.Text;
                ConfigurationWorker.ServerPort = int.Parse(this.ServerPort.Text);
                ConfigurationWorker.HideIntoTray = this.HideIntoTrayChB.Checked;
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("EXCEPTION." + ex.Message);
            }

            this.Close();
        }
    }
}
