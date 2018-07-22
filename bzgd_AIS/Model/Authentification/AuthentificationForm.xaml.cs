using System;
using System.Windows;
using System.ServiceModel;
using bzgd_dr.WCF;

namespace bzgd_AIS.Model
{
    public partial class AuthenticationWindow : Window
    {
        public AuthenticationWindow()
        {
            InitializeComponent();
        }

        private void Properties_Button_Click(object sender, RoutedEventArgs e)
        {
            var x = new bzgd_AIS.Model.GlobalControls.InitalizeConfigurationWindow();
            x.ShowDialog();
        }

        private void AuthentificationButton_Click(object sender, RoutedEventArgs e)
        {
            System.Xml.XmlDictionaryReaderQuotas quotas = new System.Xml.XmlDictionaryReaderQuotas() { MaxArrayLength = int.MaxValue };
			NetTcpBinding binding = new NetTcpBinding()
			{
				MaxReceivedMessageSize = int.MaxValue,
				ReaderQuotas = quotas
			};
			binding.Security.Mode = SecurityMode.None;
			Contract_Client contract = new Contract_Client(binding, new EndpointAddress("net.tcp://" + AppConfiguration.ConfigurationWorker.ServerIP + ":" + AppConfiguration.ConfigurationWorker.ServerPort.ToString()));
            try
            {
                if (contract.TryAuthentificate(LoginTextBox.Text, PasswordTextBox.Text))
                {
					new MainMenu.MainMenuModel(contract);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль");
                    contract.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (contract.State != CommunicationState.Faulted)
                {
                    contract.Close();
                }
            }
        }

        private void GoIntoRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
			System.Xml.XmlDictionaryReaderQuotas quotas = new System.Xml.XmlDictionaryReaderQuotas() { MaxArrayLength = int.MaxValue };
			NetTcpBinding binding = new NetTcpBinding()
			{
				MaxReceivedMessageSize = int.MaxValue,
				ReaderQuotas = quotas
			};
			binding.Security.Mode = SecurityMode.None;
			Contract_Client contract = new Contract_Client(binding, new EndpointAddress("net.tcp://" + AppConfiguration.ConfigurationWorker.ServerIP + ":" + AppConfiguration.ConfigurationWorker.ServerPort.ToString()));

            try
            {
                if (contract.Registrate(LoginTextBox.Text, PasswordTextBox.Text))
                {
                    MessageBox.Show("Пользователь создан");
                }
				else
				{
					MessageBox.Show("Не удалось зарегистрировать пользователя. Вероятно, пользователь с таким логином уже есть.");
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            contract.Close();

        }
    }
}
