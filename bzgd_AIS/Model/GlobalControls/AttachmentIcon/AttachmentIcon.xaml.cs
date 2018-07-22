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

using bzgd_dr.WCF;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF.ConnectionDataTypes;

using bzgd_AIS.Model.Helpers.ChildClasses;
using bzgd_AIS.Model.Helpers.StaticFunctions;

using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace bzgd_AIS.Model.GlobalControls
{
    public partial class AttachmentIcon : UserControl, INotifyPropertyChanged
	{
		public ShortAttachmentData _attachmentData;

		public AttachmentIcon(ShortAttachmentData attachmentData, bool withRemove)
		{
			_attachmentData = attachmentData;

			this.Resources.Add("thisClass", this);

			InitializeComponent();

			AttachName.Text = attachmentData.FileName;

			switch (attachmentData.AttachmentTypeId)
			{
				case (1):
					{
						ImageControl.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + @"/Resourses/iconFile.png", UriKind.RelativeOrAbsolute));
						break;
					}
				case (2):
					{
						ImageControl.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + @"/Resourses/imageIcon.png", UriKind.RelativeOrAbsolute));
						break;
					}
				case (3):
					{
						ImageControl.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + @"/Resourses/textIcon.png", UriKind.RelativeOrAbsolute));
						break;
					}
			}

			if (withRemove)
			{
				ImageControl.ContextMenu = (ContextMenu)(Resources["myMenu"]);
			}

			HintTB.Text = attachmentData.FileName;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
