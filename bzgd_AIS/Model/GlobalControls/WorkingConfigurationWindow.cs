using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using bzgd_AIS.AppConfiguration;

namespace bzgd_AIS.Model.GlobalControls
{
    public partial class WorkingConfigurationWindow : Form
    {
        public WorkingConfigurationWindow()
        {
            InitializeComponent();

            this.HideIntoTrayChB.Checked = ConfigurationWorker.HideIntoTray;
			this.AutoLoadChB.Checked = ConfigurationWorker.AutoRun;
		}

        private void SaveConfiguration_Click(object sender, EventArgs e)
        {
            ConfigurationWorker.HideIntoTray = this.HideIntoTrayChB.Checked;
			ConfigurationWorker.AutoRun = this.AutoLoadChB.Checked;

			this.Close();
        }
    }
}
