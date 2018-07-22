using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Serialization;


using bzgd_dr.EntityFramework;
using bzgd_dr.EntityFramework.DataTypes;
using bzgd_dr.WCF;
using bzgd_dr.WCF.ConnectionDataTypes;

namespace bzgd_dr.WCF.ConnectionDataTypes
{
    [DataContract]
    [Serializable]
    public class LongRequestWithAttachments
    {
        public LongRequestWithAttachments()
        {

        }

        public LongRequestWithAttachments(Request req, List<AttachmentData> list)
        {
            this.Request = req;
            this.attachmentList = list;
        }

        [DataMember]
        public Request Request;

        [DataMember]
        public List<AttachmentData> attachmentList = new List<AttachmentData>();
    }
}