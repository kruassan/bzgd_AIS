using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bzgd_dr.EntityFramework.DataTypes
{
    [DataContract]
    [Serializable]
    [Table("AttachmentData", Schema = "public")]
    public class AttachmentData
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DataMember]
        public byte[] content { get; set; }

        [DataMember]
        public int ordinalNumber { get; set; }

        [DataMember]
        public int AttachmentTypeId { get; set; }

        [DataMember]
        public int RequestId { get; set; }
        
        [DataMember]
        public string FileName { get; set; }

        [IgnoreDataMember]
        public AttachmentType AttachmentType { get; set; }

        [IgnoreDataMember]
        public Request Request { get; set; }
    }

}
