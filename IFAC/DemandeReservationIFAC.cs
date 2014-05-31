using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/DemandeReservationIFAC")]
	public interface DemandeReservationIFAC {
		[OperationContract]
		List<DemandeReservationBO> SelectById(String Token, Int32 pDemandeReservationId);
		
		[OperationContract]
		List<DemandeReservationBO> SelectNewByClient(String Token, ClientBO pClient);
		
		[OperationContract]
		List<DemandeReservationBO> SelectOldByClient(String Token, ClientBO pClient);

		[OperationContract]
		DemandeReservationBO InsertDemandeReservation(String Token, DemandeReservationBO pDemandeReservation);
	}
}
