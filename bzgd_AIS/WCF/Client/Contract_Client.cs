using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

using bzgd_dr.WCF.ConnectionDataTypes;
using bzgd_dr.EntityFramework.DataTypes;

namespace bzgd_dr.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Contract_Client : ClientBase<IContract>, IContract
    {
        public string myLogin { get; set; }

        public Contract_Client()
        {

        }

        public Contract_Client(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {

        }

        public Contract_Client(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {

        }

        public Contract_Client(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {

        }

        public Contract_Client(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {

        }

        public bool Registrate(string log, string pass)
        {
            bool result = Channel.Registrate(log, pass);

            return result;
        }

        public bool TryAuthentificate(string log, string pass)
        {
            bool result = Channel.TryAuthentificate(log, pass);

            if (result)
                myLogin = log;

            return Channel.TryAuthentificate(log, pass);
        }

        public ShortRequestWithAttachmentsList GetShortRequests(RequestsSearchFilter filter)
        {
            ShortRequestWithAttachmentsList result = Channel.GetShortRequests(filter);

            return result;
        }

        public LongRequestWithAttachments GetLongRequest(int id)
        {
            return Channel.GetLongRequest(id);
        }

		public AttachmentData GetAttachment(int id)
		{
			return Channel.GetAttachment(id);
		}


		public bool AddRequest(RequestWithAttachments requestWithAttachments)
        {
            return Channel.AddRequest(requestWithAttachments);
        }

		public bool RemoveRequest(ShortRequestWithAttachments requestWithAttachments)
		{
			return Channel.RemoveRequest(requestWithAttachments);
		}

		public bool ChangeRequestData(Request newRequest)
        {
            return Channel.ChangeRequestData(newRequest);
		}

		public bool AddAttachment(AttachmentData attachmentData)
		{
			return Channel.AddAttachment(attachmentData);
		}

		public bool RemoveAttachment(ShortAttachmentData attachmentData)
		{
			return Channel.RemoveAttachment(attachmentData);
		}

		public ListOfShortAttachments GetAttachmentsList()
		{
			return Channel.GetAttachmentsList();
		}

		public void Deauthentificate()
        {
            Channel.Deauthentificate();
            myLogin = "";
        }
    }
}