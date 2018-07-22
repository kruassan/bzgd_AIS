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
    [Table("AttachmentType", Schema = "public")]
    public class AttachmentType
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string type { get; set; }

        [IgnoreDataMember]
        public ICollection<AttachmentData> AttachmentData { get; set; }
    }
}
