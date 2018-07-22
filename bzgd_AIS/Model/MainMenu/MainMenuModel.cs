using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using bzgd_AIS.Model.GlobalControls;
using bzgd_AIS.Model.Helpers.ChildClasses;

using System.Collections.ObjectModel;

using bzgd_AIS.Model.GlobalControls.RequestPanel;

using bzgd_AIS.Model.MainMenu.Pages;
using bzgd_AIS.Model.RequestCreation;

using bzgd_dr.WCF;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

using System.IO;

namespace bzgd_AIS.Model.MainMenu
{
    public class MainMenuModel
    {
		public Contract_Client contract;

		RequestCreationWindow requestCreationWindow;

		AttachmentsWindow attachmentsWindow;

		public RelayCommand removeAttachmentCommand { get; set; }
		public RelayCommand downloadAttachmentCommand { get; set; }
		public RelayCommand addAttachmentCommand { get; set; }
		public RelayCommand addAttachmentToWindowCommand { get; set; }

		public Window requestDetailsForm { get; set; }

		public MainMenu mainMenu { get; set; }

		public TrayMenu programmTrayMenu { get; set; }

		public TasksPage middlePage { get; set; }

		public ObservableCollection<RequestPanel> actualRequestsList;
		public ObservableCollection<RequestPanel> ActualRequestsList
		{
			get { return actualRequestsList; }
			set { actualRequestsList = value; }
		}

		public ObservableCollection<AttachmentIcon> attachmentsList;
		public ObservableCollection<AttachmentIcon> AttachmentsList
		{
			get { return attachmentsList; }
			set { attachmentsList = value; }
		}

		public ObservableCollection<MenuButton> menuButtonsList;
		public ObservableCollection<MenuButton> MenuButtonsList
		{
			get { return menuButtonsList; }
			set { menuButtonsList = value; }
		}

		public void OpenRequestDetails(ShortRequestWithAttachments shortRequestWithAttachments)
		{
			RequestDetails.RequestDetailsModel requestDetails = new RequestDetails.RequestDetailsModel(shortRequestWithAttachments, this, (shortRequestWithAttachments.Request.login_senderId == contract.myLogin));
			requestDetails.ShowDialog();
		}

		public MainMenuModel(Contract_Client contract_Client)
		{
			this.contract = contract_Client;

			removeAttachmentCommand = new RelayCommand((x) => { RemoveAttachment((AttachmentIcon)x); });
			downloadAttachmentCommand = new RelayCommand((x) => { DownloadAttachment(((AttachmentIcon)x)._attachmentData.id); });
			addAttachmentCommand = new RelayCommand((x) => { AddAttachment(new ShortRequestWithAttachments() { attachmentList = new List<ShortAttachmentData>(), Request = new Request()}); });
			addAttachmentToWindowCommand = new RelayCommand((x) =>
			{
				AddAttachment(new ShortRequestWithAttachments() { attachmentList = new List<ShortAttachmentData>(), Request = new Request() });
				AttachmentsList = new ObservableCollection<AttachmentIcon>(contract.GetAttachmentsList().ShortAttachmentList.Select(i => new AttachmentIcon(i, false)));
				attachmentsWindow.AttachmentsField.GetBindingExpression(ItemsControl.ItemsSourceProperty).UpdateTarget();//its working!!!
			});

			ActualRequestsList = new ObservableCollection<RequestPanel>();
			this.middlePage = new TasksPage() { DataContext = this };
			InitalizeMenuButtons();
			mainMenu = new MainMenu() { DataContext = this };
			programmTrayMenu = new TrayMenu(mainMenu);


			mainMenu.Show();
			InitalizeIcon();
		}

		public void InitalizeIcon()
		{
			InitalizeMenuButtons();
			programmTrayMenu = new TrayMenu(mainMenu);

			mainMenu.ShowInTaskbar = true;
			System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
			ni.Icon = new System.Drawing.Icon(System.IO.Directory.GetCurrentDirectory() + @"/Resourses/trayIco.ico");
			ni.ContextMenu = new System.Windows.Forms.ContextMenu();

			ni.Visible = true;
			ni.Click +=
				delegate (object x1, EventArgs x2)
				{
					programmTrayMenu.Left = System.Windows.Forms.Cursor.Position.X - programmTrayMenu.Width;
					programmTrayMenu.Top = System.Windows.Forms.Cursor.Position.Y - programmTrayMenu.Height;
					programmTrayMenu.Show();
				};
		}

		public bool AddRequest(RequestWithAttachments requestWithAttachments)
		{

			return contract.AddRequest(requestWithAttachments);
		}
		public void RemoveRequest(ShortRequestWithAttachments shortRequestWithAttachments)
		{
			if(contract.RemoveRequest(shortRequestWithAttachments))
			{
				try
				{
					ActualRequestsList.Remove(ActualRequestsList.First(i => i.shortRequestWithAttachments == shortRequestWithAttachments));
				}
				catch
				{

				}
				MessageBox.Show("Задание удалено");
			}
		}
		public void UpdateRequest(ShortRequestWithAttachments shortRequestWithAttachments)
		{
			if (contract.ChangeRequestData(shortRequestWithAttachments.Request))
			{
				MessageBox.Show("Данные обновлены");
			}
		}

		public AttachmentIcon AddAttachment(ShortRequestWithAttachments shortRequestWithAttachments)
		{
			System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

			if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return null;

			FileInfo fi = new FileInfo(dialog.FileName);

			byte[] content = new byte[Convert.ToInt32(fi.Length)];
			new FileStream(dialog.FileName, FileMode.Open, FileAccess.ReadWrite).Read(content,0, Convert.ToInt32(fi.Length));

			AttachmentType type = new AttachmentType();
			AttachmentData attachmentData = new AttachmentData();
			attachmentData.AttachmentTypeId = 3;
			if (shortRequestWithAttachments.attachmentList.Count != 0)
			{
				attachmentData.ordinalNumber = shortRequestWithAttachments.attachmentList.Max(i => i.ordinalNumber) + 1;
			}
			else
			{
				attachmentData.ordinalNumber = 0;
			}

			attachmentData.RequestId = shortRequestWithAttachments.Request.Id;
			attachmentData.content = content;
			attachmentData.FileName = System.IO.Path.GetFileName(dialog.FileName);
			contract.AddAttachment(attachmentData);
			MessageBox.Show("Вложение добавлено");

			AttachmentIcon result = new AttachmentIcon(new ShortAttachmentData()
			{
				id = attachmentData.id,
				FileName = attachmentData.FileName,
				AttachmentTypeId = attachmentData.AttachmentTypeId,
				ordinalNumber = attachmentData.ordinalNumber,
				RequestId = attachmentData.RequestId
			}, false);

			return result;
		}
		public void RemoveAttachment(AttachmentIcon attachment)
		{
			contract.RemoveAttachment(attachment._attachmentData);
			MessageBox.Show("Вложение удалено");
		}

		public void DownloadAttachment(int attachmentId)
		{
			AttachmentData result = contract.GetAttachment(attachmentId);
			System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
			if(dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}
			FileStream fs = new FileStream(dialog.SelectedPath + @"\" + result.FileName, FileMode.CreateNew, FileAccess.ReadWrite);
			try
			{
				fs.Write(result.content, 0, result.content.Length);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Отказано в доступе");
			}
		}

		public void InitalizeMenuButtons()
		{
			MenuButtonsList = new ObservableCollection<MenuButton>
			{
				new MenuButton((object x) =>
				{
					ActualRequestsList = new ObservableCollection<RequestPanel>(GetRequestsList(new RequestsSearchFilter()).ToList());
					//ActualRequestsList = new ObservableCollection<RequestPanel>(GetRequestsList(new RequestsSearchFilter()).ToList());

					//foreach(var item in kek)
					//	ActualRequestsList.Add(item);
					middlePage.RequestsItemsControl.GetBindingExpression(ItemsControl.ItemsSourceProperty).UpdateTarget();//its working!!!
					//ActualRequestsList[0].OnPropertyChanged("id");//its working!
					//middlePage.RequestsItemsControl.GetBindingExpression(ContentControl.ContentProperty).UpdateTarget();
					//UpdateMiddlePage();
				},
				"Выданные задания", Directory.GetCurrentDirectory()+ @"/Resourses/gear_icon.png"),
				new MenuButton((object x) =>
				{
					requestCreationWindow = new RequestCreationWindow(this);
					requestCreationWindow.ShowDialog(); 
				}, "Создать задание", Directory.GetCurrentDirectory()+ @"/Resourses/strelka_right.png"),
				new MenuButton((object x) =>
				{
					ActualRequestsList = new ObservableCollection<RequestPanel>(GetRequestsList(new RequestsSearchFilter(){ Overdue = true }).ToList());
					middlePage.RequestsItemsControl.GetBindingExpression(ItemsControl.ItemsSourceProperty).UpdateTarget();//its working!!!
				}, "Просроченные", Directory.GetCurrentDirectory() + @"/Resourses/strelka_right.png"),
				new MenuButton((object x) => { new WorkingConfigurationWindow().ShowDialog(); }, "Параметры", Directory.GetCurrentDirectory() + @"/Resourses/strelka_right.png"),
				new MenuButton((object x) =>
				{
					AttachmentsList = new ObservableCollection<AttachmentIcon>(contract.GetAttachmentsList().ShortAttachmentList.Select(i => new AttachmentIcon(i, false)));
					attachmentsWindow = new AttachmentsWindow() { DataContext = this };
					attachmentsWindow.Show();
				}, "Вложения в системе", Directory.GetCurrentDirectory() + @"/Resourses/iconFile.png")
			};
		}

		public List<RequestPanel> GetRequestsList(RequestsSearchFilter filter)
		{
			ShortRequestWithAttachmentsList requestsFromContractList = contract.GetShortRequests(filter);

			List<ShortRequestWithAttachments> requestsFromContract = requestsFromContractList.ShortRequestWithAttachments;

			var result = requestsFromContract.Select((x) =>
			{
				return new RequestPanel(x, this);
			});

			return result.ToList();
		}


	}
}
