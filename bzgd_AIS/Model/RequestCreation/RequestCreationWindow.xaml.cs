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

using bzgd_AIS.Model.GlobalControls;

using System.Collections.ObjectModel;
using System.IO;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

namespace bzgd_AIS.Model.RequestCreation
{
	/// <summary>
	/// Логика взаимодействия для RequestCreation.xaml
	/// </summary>
	public partial class RequestCreationWindow : Window
	{
		DateTime dtFrom;
		DateTime dtTo;
		MainMenu.MainMenuModel menuHandle;

		RequestWithAttachments requestWithAttachments = new RequestWithAttachments();

		ObservableCollection<AttachmentIcon> attachmentIcons = new ObservableCollection<AttachmentIcon>();
		public ObservableCollection<AttachmentIcon> AttachmentIcons
		{
			get { return attachmentIcons; }
			set { attachmentIcons = value; }
		}

		public RequestCreationWindow(MainMenu.MainMenuModel mainMenuHandle)
		{
			menuHandle = mainMenuHandle;

			this.DataContext = this;

			InitializeComponent();
		}

		private void InsertAttachment(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

			if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			FileInfo fi = new FileInfo(dialog.FileName);

			byte[] attach_content = new byte[Convert.ToInt32(fi.Length)];
			FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.ReadWrite);
			fs.Read(attach_content, 0, Convert.ToInt32(fi.Length));

			AttachmentIcons.Add(new AttachmentIcon(new ShortAttachmentData()
			{
				AttachmentTypeId = 1,
				FileName = System.IO.Path.GetFileName(dialog.FileName)
			}, false));

			requestWithAttachments.attachmentList.Add(new AttachmentData()
			{
				AttachmentTypeId = 1,
				FileName = System.IO.Path.GetFileName(dialog.FileName),
				id = 0,
				RequestId = 0,
				content = attach_content
			});
		}

		private void AcceptAttachment(object sender, RoutedEventArgs e)
		{
			if(dtFrom == null)
			{
				MessageBox.Show("Дата начала некорректна");
				return;
			}

			if (dtTo == null)
			{
				MessageBox.Show("Дата окончания некорректна");
				return;
			}


			requestWithAttachments.Request = new Request()
			{
				caption = RequestCaption.Text,
				recourse = RequestRecource.Text,
				Id = 0,
				hasAttachments = attachmentIcons.Count != 0,
				login_senderId = menuHandle.contract.myLogin,
				login_recieverId = TargetOfRequest.Text,
				date_from = dtFrom,
				date_to = dtTo
			};

			
			if(menuHandle.AddRequest(requestWithAttachments))
			{
				MessageBox.Show("Задание добавлено");
				this.Close();
			}
		}

		private void DateFromCalendarSelect(object sender, RoutedEventArgs e)
		{
			CalendarRetDate calendar = new CalendarRetDate();
			calendar.ShowDialog();
			if (calendar.DialogResult == false || calendar.AnswerDate == null)
			{
				return;
			}

			dtFrom = (DateTime)(calendar.AnswerDate);

			this.MaskedTB_FROM.Text = ToFourOrMoreSymbols(dtFrom.Year.ToString()) +
				ToTwoOrMoreSymbols(dtFrom.Month.ToString()) +
				ToTwoOrMoreSymbols(dtFrom.Day.ToString()) +
				ToTwoOrMoreSymbols(dtFrom.Hour.ToString()) +
				ToTwoOrMoreSymbols(dtFrom.Minute.ToString());
		}

		private void DateToCalendarSelect(object sender, RoutedEventArgs e)
		{
			CalendarRetDate calendar = new CalendarRetDate();
			calendar.ShowDialog();
			if (calendar.DialogResult == false || calendar.AnswerDate == null)
			{
				return;
			}

			dtTo = (DateTime)(calendar.AnswerDate);

			this.MaskedTB_TO.Text = ToFourOrMoreSymbols(dtTo.Year.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Month.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Day.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Hour.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Minute.ToString());
		}

		private string FormattedDateTime(DateTime dateTime)
		{
			return ToFourOrMoreSymbols(dateTime.Year.ToString()) +
				ToTwoOrMoreSymbols(dateTime.Month.ToString()) +
				ToTwoOrMoreSymbols(dateTime.Day.ToString()) +
				ToTwoOrMoreSymbols(dateTime.Hour.ToString()) +
				ToTwoOrMoreSymbols(dateTime.Minute.ToString());
		}

		private string ToFourOrMoreSymbols(string val)
		{
			switch (val.Length)
			{
				case (0):
					{
						return "0000";
					}
				case (1):
					{
						return "000" + val;
					}
				case (2):
					{
						return "00" + val;
					}
				case (3):
					{
						return "0" + val;
					}
				default:
					{
						return val;
					}
			}
		}

		private string ToTwoOrMoreSymbols(string val)
		{
			switch (val.Length)
			{
				case (0):
					{
						return "00";
					}
				case (1):
					{
						return "0" + val;
					}
				default:
					{
						return val;
					}
			}
		}
	}
}
