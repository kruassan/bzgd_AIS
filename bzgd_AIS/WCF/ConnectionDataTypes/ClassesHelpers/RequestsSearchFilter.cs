using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity;

using bzgd_dr.EntityFramework;
using bzgd_dr.EntityFramework.DataTypes;

namespace bzgd_dr.WCF.ConnectionDataTypes
{
    [DataContract]
    [Serializable]
    public enum RequestCompletion { Not_started = 0, In_progress_0, In_progress_25, In_progress_50, In_progress_75, Completed }

    [DataContract]
    [Serializable]
    public class RequestsSearchFilter
    {
        public List<Request> FiltredCollection(IEnumerable<Request> request)
        {
            if (Sender != null)
            {
                request = request.Where(i => i.login_senderId == Sender);
            }

            if (Reciever != null)
            {
                request = request.Where(i => i.login_recieverId == Reciever);
            }

            if(HasAttachments == true)
            {
                request = request.Where(i => i.hasAttachments == true);
            }

            if (Overdue == true)
            {
                request = request.Where(i => i.date_to < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            }

            if(Date_from != null)
            {
                request = request.Where(i => i.date_from >= Date_from);
            }
            if (Date_to != null)
            {
                request = request.Where(i => i.date_to <= Date_to);
            }

            return request.ToList();
        }

        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public string Reciever { get; set; }

        [DataMember]
        public DateTime? Date_from { get; set; }

        [DataMember]
        public DateTime? Date_to { get; set; }

        [DataMember]
        public bool? HasAttachments { get; set; }

        [DataMember]
        public bool? Overdue { get; set; }//просроченный

        [DataMember]
        public RequestCompletion? RequestCompletion { get; set; }
    }
}
