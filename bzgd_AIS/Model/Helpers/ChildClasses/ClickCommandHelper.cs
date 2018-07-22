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

namespace bzgd_AIS.Model.Helpers.ChildClasses
{
    public class ClickCommand : ICommand
    {
        public event Action act;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (act != null && act.GetInvocationList().Length != 0)
            {
                act();
            }
        }
    }
}
