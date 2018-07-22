using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity;

namespace bzgd_dr.EntityFramework.DataTypes
{
    [DataContract]
    [Serializable]
    [Table("User", Schema = "public")]
    public class User
    {
        [DataMember]
        [Key]
        public string login { get; set; }

        [DataMember]
        public string passHash { get; set; }

        [DataMember]
        public int role { get; set; }

        [IgnoreDataMember]
        public ICollection<Request> SentRequests { get; set; }

        [IgnoreDataMember]
        public ICollection<Request> ReceivedRequests { get; set; }

    }
}
