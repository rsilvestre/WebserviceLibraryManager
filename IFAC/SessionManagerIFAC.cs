using System;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/SessionManagerIFAC")]
	public interface SessionManagerIFAC {
		[OperationContract]
		SessionManagerBO OpenSession(String pUsername, String pPassword);
	}
}
