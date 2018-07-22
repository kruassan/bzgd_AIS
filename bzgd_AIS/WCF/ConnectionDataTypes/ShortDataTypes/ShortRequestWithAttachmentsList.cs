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
    public class ShortRequestWithAttachmentsList
    {
        List<ShortRequestWithAttachments> requestWithAttachments = new List<ShortRequestWithAttachments>();

        [DataMember]
        public List<ShortRequestWithAttachments> ShortRequestWithAttachments
        {
            get { return requestWithAttachments; }
            set { requestWithAttachments = value; }
        }
    }
}