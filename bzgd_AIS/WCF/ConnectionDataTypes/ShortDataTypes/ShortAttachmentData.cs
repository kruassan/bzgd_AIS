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
    public class ShortAttachmentData
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int ordinalNumber { get; set; }

        [DataMember]
        public int AttachmentTypeId { get; set; }

        [DataMember]
        public int RequestId { get; set; }

        [DataMember]
        public string FileName { get; set; }
    }

}