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

using System.Collections;
using System.Collections.ObjectModel;

using System.ComponentModel;

using bzgd_dr.WCF;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

using bzgd_AIS.Model.Helpers;
using bzgd_AIS.Model.Helpers.ChildClasses;
using bzgd_AIS.Model.Helpers.StaticFunctions;

namespace bzgd_AIS.Model.GlobalControls.RequestPanel
{
    public partial class RequestPanel : UserControl, INotifyPropertyChanged
    {
		public ShortRequestWithAttachments shortRequestWithAttachments { get; set; }

		MainMenu.MainMenuModel _mainMenuHandle;
		ShortRequestWithAttachments _shortRequest;
		public ObservableCollection<AttachmentIcon> AttachmentIcons
		{
			get;
			set;
		}

        public RequestPanel(ShortRequestWithAttachments shortRequest, MainMenu.MainMenuModel mainMenuHandle)
		{
			this.shortRequestWithAttachments = shortRequest;

			_mainMenuHandle = mainMenuHandle;
			_shortRequest = shortRequest;

			this.Resources.Add("this", this);

			AttachmentIcons = new ObservableCollection<AttachmentIcon>();
			foreach (var item in shortRequest.attachmentList)
			{
				AttachmentIcons.Add(new AttachmentIcon(item, true) { DataContext = mainMenuHandle });
			}
			this.DataContext = this;

			InitializeComponent();

			bool fromMe = mainMenuHandle.contract.myLogin == shortRequest.Request.login_senderId;
			this.FromOrToTB.Text = fromMe ? "От меня" : "Ко мне";

			this.FromOrToTB.Background = fromMe ? Brushes.LightGreen : Brushes.LightPink;
			
			this.DateFromTB.Text = shortRequest.Request.date_from.ToLongDateString();
			this.DateToTB.Text = shortRequest.Request.date_to.ToLongDateString();
			this.StatusTB.Text = shortRequest.Request.RequestStatusId.ToString();
			this.LoginSenderTB.Text = shortRequest.Request.login_senderId;
			this.LoginRecieverTB.Text = shortRequest.Request.login_recieverId;
			this.CaptionTB.Text = shortRequest.Request.caption;
        }

		private void GetDetails(object sender, RoutedEventArgs e)
		{
			_mainMenuHandle.OpenRequestDetails(_shortRequest);
		}

		public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }		
	}
}
