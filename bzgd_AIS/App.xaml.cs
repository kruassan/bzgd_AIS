using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace bzgd_AIS
{

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bzgd_AIS.Model.AuthenticationWindow x = new bzgd_AIS.Model.AuthenticationWindow();

            x.Show();
        }
    }
}