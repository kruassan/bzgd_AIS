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
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        bool Registrate(string log, string pass);

        [OperationContract]
        bool TryAuthentificate(string log, string pass);

        [OperationContract]
        ShortRequestWithAttachmentsList GetShortRequests(RequestsSearchFilter filter);

        [OperationContract]
        LongRequestWithAttachments GetLongRequest(int id);

		[OperationContract]
		AttachmentData GetAttachment(int id);

        [OperationContract]
        bool AddRequest(RequestWithAttachments requestWithAttachments);

		[OperationContract]
		bool RemoveRequest(ShortRequestWithAttachments requestWithAttachments);

		[OperationContract]
        bool ChangeRequestData(Request newRequest);

		[OperationContract]
		bool AddAttachment(AttachmentData attachmentData);

		[OperationContract]
		bool RemoveAttachment(ShortAttachmentData attachmentData);

		[OperationContract]
		ListOfShortAttachments GetAttachmentsList();

		[OperationContract]
        void Deauthentificate();
    }
}