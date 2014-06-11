using System;
using System.Collections.Generic;
using WebsBO;
using System.ServiceModel;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/ItemIFAC")]
    public interface ItemIFAC {
		[OperationContract]
		List<ItemBO> SelectAll(String token);

		[OperationContract]
		ItemBO SelectByItemId(String token, Int32 pItemId);

		[OperationContract]
		ItemBO SelectByEmpruntId(String token, Int32 pEmpruntId);

		[OperationContract]
		List<ItemBO> SelectByAdministrateurId(String token, Int32 pAdministrateurId);
    }
}
