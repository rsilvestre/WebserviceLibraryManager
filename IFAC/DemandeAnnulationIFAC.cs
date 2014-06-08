using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/DemandeAnnulationIFAC")]
	public interface DemandeAnnulationIFAC {
		
		[OperationContract]
		List<DemandeAnnulationBO> SelectById(String Token, Int32 pDemandeAnnulationId);

		[OperationContract]
		DemandeAnnulationBO InsertDemandeAnnulationByAdmininistrateur(String token, Int32 pAdministrateurId, Int32 pDemandeReservationId);

		[OperationContract]
		DemandeAnnulationBO InsertDemandeAnnulationByClient(String token, Int32 pClientId, Int32 pDemandeReservationId);
	}
}
