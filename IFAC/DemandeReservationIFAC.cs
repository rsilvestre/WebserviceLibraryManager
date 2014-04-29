using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="WebsIFAC/DemandeReservationIFAC")]
	public interface DemandeReservationIFAC {
		[OperationContract]
		List<DemandeReservationBO> SelectById(String Token, Int32 pDemandeReservationId);
	}
}
