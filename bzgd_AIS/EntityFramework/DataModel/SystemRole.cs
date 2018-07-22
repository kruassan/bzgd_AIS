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
    [Table("SystemRole", Schema = "public")]
    public class SystemRole
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string role { get; set; }

        [IgnoreDataMember]
        public DbSet<User> Users { get; set; }
    }
}
