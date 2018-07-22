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
using System.Configuration;

using bzgd_AIS.Model.Helpers.ChildClasses;

namespace bzgd_AIS.Model.MainMenu.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPropertiesPage.xaml
    /// </summary>
    public partial class UserPropertiesPage : Page
    {
        //private RelayCommand saveConfigurationCommand;
        //public RelayCommand SaveConfigurationCommand
        //{
        //    get
        //    {
        //        return saveConfigurationCommand;
        //    }
        //}

        public UserPropertiesPage()
        {
            InitializeComponent();
            //this.AutoRunItem.SelectedIndex = ConfigurationManager.AppSettings["AutoRun"] == "false" ? 1: 0;
            //this.HideIntoTrayItem.SelectedIndex = ConfigurationManager.AppSettings["HideIntoTray"] == "false" ? 1 : 0;
            //this.ReloadInterval.Text = ConfigurationManager.AppSettings["ReloadInterval"];
            //this.DataContext = this;
            //saveConfigurationCommand = new RelayCommand((o) => {
            //    UpdateConfiguration();
            //    MessageBox.Show("Изменения будут применены при перезапуске программы"); });
        }

        private void UpdateConfiguration()
        {
            //Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //currentConfig.AppSettings.Settings["AutoRun"].Value = this.AutoRunItem.Text == "Да" ? "true" : "false";
            //currentConfig.AppSettings.Settings["HideIntoTray"].Value = this.HideIntoTrayItem.Text == "Да" ? "true" : "false";
            //currentConfig.AppSettings.Settings["ReloadInterval"].Value = this.ReloadInterval.Text;
            //currentConfig.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");

        }
    }
}
