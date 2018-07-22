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

using bzgd_dr.WCF;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

using System.Collections.ObjectModel;

namespace bzgd_AIS.Model.GlobalControls
{
    public partial class RequestDetailsForm : Window
	{
		public DateTime dtTo;

		public RequestDetailsForm(ShortRequestWithAttachments shortRequestWithAttachments, bool RequestForUser)
		{			
			InitializeComponent();

			this.CompletionStage.SelectedIndex = shortRequestWithAttachments.Request.RequestStatusId;

			if (!RequestForUser)
			{
				this.AddAttachmentButton.Visibility = Visibility.Hidden;
				this.RemoveRequestButton.Visibility = Visibility.Hidden;
				this.MessageTextBox.IsReadOnly = true;
				this.DateToStackPanel.IsEnabled = false;
			}

			dtTo = shortRequestWithAttachments.Request.date_to;

			this.MaskedTB_TO.Text = ToFourOrMoreSymbols(dtTo.Year.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Month.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Day.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Hour.ToString()) +
				ToTwoOrMoreSymbols(dtTo.Minute.ToString());

			this.Resources.Add("this", this);
			this.SenderTB.Text = shortRequestWithAttachments.Request.login_senderId;
			this.RecieverTB.Text = shortRequestWithAttachments.Request.login_recieverId;
			this.MessageTextBox.Text = shortRequestWithAttachments.Request.recourse;
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
