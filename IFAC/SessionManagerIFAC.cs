using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/SessionManagerIFAC")]
	public interface SessionManagerIFAC {
		[OperationContract]
		SessionManagerBO OpenSession(String pUsername, String pPassword);
	}
}
