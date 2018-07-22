using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Interactivity;

using bzgd_AIS.Model.GlobalControls;

using bzgd_AIS.Model.Helpers;
using bzgd_AIS.Model.Helpers.ChildClasses;
using bzgd_AIS.Model.Helpers.StaticFunctions;

using System.Collections.ObjectModel;

using bzgd_AIS.Model.GlobalControls.RequestPanel;

using bzgd_AIS.Model.MainMenu.Pages;

using bzgd_dr.WCF;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

using System.IO;

namespace bzgd_AIS.Model.MainMenu
{    
    public partial class MainMenu : Window
    {
        public MainMenu()
		{
			InitializeComponent();
		}
    }
}
