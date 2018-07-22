using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Serialization;

using bzgd_dr.EntityFramework.DataTypes;

using bzgd_dr.EntityFramework;

namespace bzgd_dr.WCF.ConnectionDataTypes
{
    [DataContract]
    [Serializable]
    public class ShortRequestWithAttachments
    {
        public ShortRequestWithAttachments()
        {

        }

        public ShortRequestWithAttachments(Request req, List<ShortAttachmentData> list)
        {
            this.Request = req;
            this.attachmentList = list;
        }

        [DataMember]
        public Request Request;

        [DataMember]
        public List<ShortAttachmentData> attachmentList = new List<ShortAttachmentData>();
    }
}