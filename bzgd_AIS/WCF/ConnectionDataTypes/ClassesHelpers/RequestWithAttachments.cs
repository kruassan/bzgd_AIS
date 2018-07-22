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
    public class RequestWithAttachments
    {
        public RequestWithAttachments()
        {

        }

        public RequestWithAttachments(Request req, List<AttachmentData> list)
        {
            this.Request = req;
            this.attachmentList = list;
        }
        [DataMember]
        public Request Request;

        [DataMember]
        public List<AttachmentData> attachmentList = new List<AttachmentData>();
    }

    //[DataContract]
    //public class RequestWithAttachmentsList
    //{
    //    List<RequestWithAttachments> requestWithAttachments = new List<RequestWithAttachments>();

    //    [DataMember]
    //    public List<RequestWithAttachments> RequestWithAttachments
    //    {
    //        get { return requestWithAttachments; }
    //        set { requestWithAttachments = value; }
    //    }
    //}
}

