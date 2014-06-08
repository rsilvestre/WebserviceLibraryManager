using System;
using System.Collections.Generic;
using WebsBO;
using System.ServiceModel;

namespace WebsIFAC {
	[ServiceContract(Namespace="uri:WebsIFAC/LivreStatusIFAC")]
	public interface LivreStatusIFAC {
		[OperationContract]
		List<LivreStatusBO> SelectAll(String Token);
	
	}
}
