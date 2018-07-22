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

using bzgd_AIS.Model.GlobalControls;

using bzgd_AIS.Model.Helpers;
using bzgd_AIS.Model.Helpers.ChildClasses;
using bzgd_AIS.Model.Helpers.StaticFunctions;

using System.Collections.ObjectModel;

using bzgd_AIS.Model.GlobalControls.RequestPanel;

using bzgd_AIS.Model.MainMenu.Pages;

using bzgd_dr.WCF;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

using System.IO;

namespace bzgd_AIS.Model.RequestDetails
{
	class RequestDetailsModel
	{
		public int RequestStatusId = 2;

		public RelayCommand removeAttachmentCommand { get; set; }
		public RelayCommand downloadAttachmentCommand { get; set; }

		public RelayCommand removeRequestCommand { get; set; }
		public RelayCommand updateRequestCommand { get; set; }
		public RelayCommand addAttachmentCommand { get; set; }


		public RequestDetailsForm requestDetailsForm { get; set; }

		public ObservableCollection<AttachmentIcon> attachmentIcons { get; set; }

		Action<ShortRequestWithAttachments> RemoveRequest;
		Action<ShortRequestWithAttachments> UpdateRequest;
		Action<ShortRequestWithAttachments> AddAttachment;
		Action<AttachmentIcon> RemoveAttachment;
		
		public RequestDetailsModel(ShortRequestWithAttachments shortRequestWithAttachments, MainMenu.MainMenuModel modelHandle, bool FromUser)
		{
			this.RemoveRequest = modelHandle.RemoveRequest;
			this.removeRequestCommand = new RelayCommand((x) => { RemoveRequest(shortRequestWithAttachments); requestDetailsForm.Close(); });

			this.UpdateRequest = modelHandle.UpdateRequest;
			if (FromUser)
			{
				this.updateRequestCommand = new RelayCommand((x) =>
				{
					ShortRequestWithAttachments request = shortRequestWithAttachments;
					request.Request.recourse = requestDetailsForm.MessageTextBox.Text;
					request.Request.RequestStatusId = requestDetailsForm.CompletionStage.SelectedIndex;

					if (requestDetailsForm.dtTo != null)
					{
						request.Request.date_to = requestDetailsForm.dtTo;
					}

					UpdateRequest(request);
				});
			}
			else
			{
				this.updateRequestCommand = new RelayCommand((x) =>
				{
					ShortRequestWithAttachments request = shortRequestWithAttachments;
					request.Request.RequestStatusId = requestDetailsForm.CompletionStage.SelectedIndex;

					UpdateRequest(request);
				});
			}

			this.AddAttachment = (x) => {
				var result = modelHandle.AddAttachment(x);
				attachmentIcons.Add(result);
			};
			this.addAttachmentCommand = new RelayCommand((x) => { AddAttachment(shortRequestWithAttachments); });

			this.RemoveAttachment = modelHandle.RemoveAttachment;
			this.removeAttachmentCommand = new RelayCommand((x) => { modelHandle.RemoveAttachment(((AttachmentIcon)x)); attachmentIcons.Remove((AttachmentIcon)x); });

			attachmentIcons = new ObservableCollection<AttachmentIcon>();
			foreach (var item in shortRequestWithAttachments.attachmentList)
			{
				attachmentIcons.Add(new AttachmentIcon(item, true) { DataContext = modelHandle });
			}

			requestDetailsForm = new RequestDetailsForm(shortRequestWithAttachments, FromUser) { DataContext = this };
		}

		public void Show()
		{
			requestDetailsForm.Show();
		}	

		public void ShowDialog()
		{
			requestDetailsForm.ShowDialog();
		}
	}
}