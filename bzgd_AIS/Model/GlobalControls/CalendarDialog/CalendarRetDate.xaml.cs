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

namespace bzgd_AIS.Model.GlobalControls
{
    /// <summary>
    /// Логика взаимодействия для CalendarRetDate.xaml
    /// </summary>
    public partial class CalendarRetDate : Window
    {
        public DateTime? AnswerDate
        {
            get { return WorkingCalendar.SelectedDate; }
        }

        public CalendarRetDate()
        {
            InitializeComponent();
           
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            if(WorkingCalendar.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Пожалуиста, выберите дату");
                return;
            }
            this.DialogResult = true;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
