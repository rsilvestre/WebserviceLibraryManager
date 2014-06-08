using System;
using System.Collections.Generic;
using WebsBO;
using System.ServiceModel;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/ClientIFAC")]
    public interface ClientIFAC {
		[OperationContract]
		List<ClientBO> SelectAll(String Token);

		[OperationContract]
		ClientBO SelectById(String Token, int pId);
    }
}
