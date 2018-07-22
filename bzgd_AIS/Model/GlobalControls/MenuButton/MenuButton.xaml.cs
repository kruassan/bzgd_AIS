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
using System.IO;

using bzgd_AIS.Model.Helpers.ChildClasses;

namespace bzgd_AIS.Model.GlobalControls
{
    /// <summary>
    /// Логика взаимодействия для MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public Image MenuButtonImage
        {
            get;
            set;
        }

        public string ButtonCaption
        {
            get;
            set;
        }

        public string ImageSource
        {
            get;
            set;
        }

		private RelayCommand menuButtonClick;
        public RelayCommand MenuButtonClick
        {
            get
            {
                return menuButtonClick;
            }
        }

        public MenuButton(Action<object> onClick, string caption, string imgSrc)
        {
            this.ImageSource = imgSrc;
            menuButtonClick = new RelayCommand(onClick);
            ButtonCaption = caption;
            this.DataContext = this;

            InitializeComponent();
        }
        
    }
}
