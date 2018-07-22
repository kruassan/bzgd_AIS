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


using bzgd_AIS.Model.Helpers.ChildClasses;
using bzgd_AIS.Model.Helpers.StaticFunctions;

namespace bzgd_AIS.Model.GlobalControls
{
    /// <summary>
    /// Логика взаимодействия для HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl
    {
        public ClickCommand minimizeCommand { get; set; } = new ClickCommand();
        public ClickCommand maximizeCommand { get; set; } = new ClickCommand();
        public ClickCommand closeCommand { get; set; } = new ClickCommand();
        public ClickCommand dragMoveCommand { get; set; } = new ClickCommand();

        public string HideIntoTray
        {
            get { return (string)GetValue(HideIntoTrayProperty); }
            set { SetValue(HideIntoTrayProperty, value); }
        }

        public static readonly DependencyProperty HideIntoTrayProperty =
           DependencyProperty.Register("HideIntoTray", typeof(string),
           typeof(HeaderControl), new UIPropertyMetadata("False"));


        public string HeaderCaption
        {
            get { return (string)GetValue(HeaderCaptionProperty); }
            set { SetValue(HeaderCaptionProperty, value); }
        }

        public static readonly DependencyProperty HeaderCaptionProperty =
           DependencyProperty.Register("HeaderCaption", typeof(string),
           typeof(HeaderControl), new UIPropertyMetadata(""));

        public HeaderControl()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            minimizeCommand.act += () => { WindowStaticFunctionsHelper.MinimizeForm(Window.GetWindow(this)); };
            maximizeCommand.act += () => { WindowStaticFunctionsHelper.ResizeForm(Window.GetWindow(this)); };

            if (HideIntoTray == "True")
            {
                closeCommand.act += () => { WindowStaticFunctionsHelper.CloseOrHideForm(Window.GetWindow(this)); };
            }
            else
            {
                closeCommand.act += () => { WindowStaticFunctionsHelper.CloseForm(Window.GetWindow(this)); };
            }

            dragMoveCommand.act += () => { WindowStaticFunctionsHelper.WindowDragMove(Window.GetWindow(this)); };
        }
    }
}
