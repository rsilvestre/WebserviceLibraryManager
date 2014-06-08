using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/DemandeReservationIFAC")]
	public interface DemandeReservationIFAC {
		[OperationContract]
		DemandeReservationBO SelectById(String token, Int32 pDemandeReservationId);
		
		[OperationContract]
		List<DemandeReservationBO> SelectAll(String token);
		
		[OperationContract]
		List<DemandeReservationBO> SelectNewByClient(String token, ClientBO pClient);
		
		[OperationContract]
		List<DemandeReservationBO> SelectOldByClient(String token, ClientBO pClient);

		[OperationContract]
		DemandeReservationBO InsertDemandeReservation(String token, DemandeReservationBO pDemandeReservation);
	}
}
