using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft;
using Microsoft.Windows;
using Microsoft.Win32;

using System.Configuration;

using System.Net;

namespace bzgd_AIS.AppConfiguration
{
    static class ConfigurationWorker
    {
        private static Configuration confCollection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static string ServerIP
        {
            get
            {
                string val = confCollection.AppSettings.Settings["ServerIP"].Value;

                IPAddress useless = new IPAddress(0x0);
                bool validate = IPAddress.TryParse(val, out useless);

               // if (!validate && val.Replace(" ", "") != "localhost")
                    //throw new ArgumentException("В конфигурационном файле обнаружен некорректный ip адрес");

                return confCollection.AppSettings.Settings["ServerIP"].Value;
            }
            set
            {
                IPAddress useless = new IPAddress(0x0);
                bool validate = IPAddress.TryParse(value, out useless);

                if (!validate && value.Replace(" ","") != "localhost")
                    throw new ArgumentException("Не корректный ip адрес");

                confCollection.AppSettings.Settings["ServerIP"].Value = value;
                confCollection.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
            }
        }

        public static int ServerPort
        {
            get
            {
                int result = 0;
                string val = confCollection.AppSettings.Settings["ServerPort"].Value;
                bool validate = int.TryParse(val, out result);
                if (!validate || result < 0)
                {
                    confCollection.AppSettings.Settings["ServerPort"].Value = (1).ToString();
                    confCollection.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
                    //throw new ArgumentException("Не корректное значение порта в конфигурационном файле. В файле конфигурации присовено значение 1. Переданное значение:" + val);
                }

                return result;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Значение порта не может быть меньше нуля. Переданное значение:" + value);
                }
                confCollection.AppSettings.Settings["ServerPort"].Value = value.ToString();
                confCollection.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
            }
        }

        public static bool HideIntoTray
        {
            get
            {
                bool result = false;
                string val = confCollection.AppSettings.Settings["HideIntoTray"].Value;
                bool validate = bool.TryParse(val, out result);
                if (!validate)
                {
                    confCollection.AppSettings.Settings["HideIntoTray"].Value = false.ToString();
                    confCollection.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
                    //throw new ArgumentException("Не корректное значение HideIntoTray в конфигурационном файле. В файле конфигурации присовено значение false. Переданное значение:" + val);
                }

                return result;
            }
            set
            {
                confCollection.AppSettings.Settings["HideIntoTray"].Value = value.ToString();
                confCollection.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
            }
        }

        public static bool AutoRun
        {
            get
            {
                bool result = false;
                string val = confCollection.AppSettings.Settings["AutoRunWithWindows"].Value;
                bool validate = bool.TryParse(val, out result);
                if (!validate)
                {
                    confCollection.AppSettings.Settings["AutoRunWithWindows"].Value = false.ToString();
                    confCollection.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
                    //throw new ArgumentException("Не корректное значение AutoRunWithWindows в конфигурационном файле. В файле конфигурации присовено значение false. Переданное значение:" + val);
                }

                return result;
            }
            set
            {
				if(value)
				{
					RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
					key.SetValue("bzgd_dr_AIS", System.Reflection.Assembly.GetEntryAssembly().Location);
				}
				else
				{
					RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
					key.DeleteValue("bzgd_dr_AIS", false);
				}
                confCollection.AppSettings.Settings["AutoRunWithWindows"].Value = value.ToString();
                confCollection.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(confCollection.AppSettings.SectionInformation.Name);
            }
        }
    }
}