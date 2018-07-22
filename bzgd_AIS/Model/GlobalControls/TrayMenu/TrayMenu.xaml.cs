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
using System.Windows.Shapes;

using bzgd_AIS.Model.Helpers.ChildClasses;
using bzgd_AIS.Model.Helpers.StaticFunctions;

namespace bzgd_AIS.Model.GlobalControls
{
    /// <summary>
    /// Логика взаимодействия для TrayMenu.xaml
    /// </summary>
    public partial class TrayMenu : Window
    {
        Window openingWindow;

        public ClickCommand dragMoveCommand { get; set; } = new ClickCommand();
        public ClickCommand AppOpenClick { get; set; } = new ClickCommand();
        public ClickCommand AppExitClick { get; set; } = new ClickCommand();

        


        public TrayMenu(Window window)
        {
            this.openingWindow = window;

            DataContext = this;

            dragMoveCommand.act += () => { WindowStaticFunctionsHelper.WindowDragMove(Window.GetWindow(this)); };
            AppOpenClick.act += () => { openingWindow.Show(); this.Hide(); };
            AppExitClick.act += () => { Application.Current.Shutdown(); };

            InitializeComponent();
        }
    }
}
