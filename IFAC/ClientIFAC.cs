using System;
using System.Collections.Generic;
using WebsBO;
using System.ServiceModel;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/ClientIFAC")]
    public interface ClientIFAC {
		[OperationContract]
		List<ClientBO> SelectAll(String token);

		[OperationContract]
		ClientBO SelectById(String token, Int32 pId);
    }
}
