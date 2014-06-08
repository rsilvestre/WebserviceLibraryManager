using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/PersonneIFAC")]
	public interface PersonneIFAC {

		[OperationContract]
		List<PersonneBO> SelectAll(String token);

		[OperationContract]
		PersonneBO SelectById(String token, Int32 pId);

		[OperationContract]
		List<PersonneBO> SelectByName(String token, String pName);

		[OperationContract]
		List<PersonneBO> SelectByInfo(String token, String pInfo);

		[OperationContract]
		PersonneBO SelectByLivreEmpruntId(String token, Int32 pEmpruntId);
	}
}
