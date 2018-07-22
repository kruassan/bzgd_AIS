using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Serialization;

namespace bzgd_dr.WCF.ConnectionDataTypes
{
	[DataContract]
	[Serializable]
	public class ListOfShortAttachments
	{
		List<ShortAttachmentData> shortAttachmentList = new List<ShortAttachmentData>();

		[DataMember]
		public List<ShortAttachmentData> ShortAttachmentList
		{
			get { return shortAttachmentList; }
			set { shortAttachmentList = value; }
		}
	}
}
