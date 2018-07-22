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

namespace bzgd_AIS.Model.Helpers.StaticFunctions
{
    static class WindowStaticFunctionsHelper
    {
        public static void MinimizeForm(Window window)
        {
            window.WindowState = window.WindowState == WindowState.Minimized ? WindowState.Normal : WindowState.Minimized;
        }

        public static void ResizeForm(Window window)
        {
            window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        public static void CloseForm(Window window)
        {
            window.Close();
        }

        public static void CloseOrHideForm(Window window)
        {
            if (AppConfiguration.ConfigurationWorker.HideIntoTray)
            {                
                window.Hide();
            }
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        public static void WindowDragMove(Window window)
        {
            try
            {
                window.DragMove();
            }
            catch
            {

            }
        }

    }
}
