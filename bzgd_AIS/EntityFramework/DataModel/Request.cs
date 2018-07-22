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
    [Table("Request", Schema = "public")]
    public class Request
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string caption { get; set; }

        [DataMember]
        public bool hasAttachments { get; set; }

        [DataMember]
        public DateTime date_from { get; set; }

        [DataMember]
        public DateTime date_to { get; set; }

        [DataMember]
        [ForeignKey("login_sender")]
        public string login_senderId { get; set; }

        [DataMember]
        [ForeignKey("login_reciever")]
        public string login_recieverId { get; set; }

        [DataMember]
        public int RequestStatusId { get; set; }

        [DataMember]
        public string recourse { get; set; }

        [IgnoreDataMember]
        [InverseProperty("SentRequests")]
        public User login_sender { get; set; }

        [IgnoreDataMember]
        [InverseProperty("ReceivedRequests")]
        public User login_reciever { get; set; }

        [IgnoreDataMember]
        public RequestStatus RequestStatus { get; set; }

        [IgnoreDataMember]
        public ICollection<AttachmentData> AttachmentData { get; set; }
    }
}
