using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/AdministrateurIFAC")]
	public interface AdministrateurIFAC {
	
		[OperationContract]
		AdministrateurBO SelectById(String Token, Int32 pAdministrateurId);
	}
}
