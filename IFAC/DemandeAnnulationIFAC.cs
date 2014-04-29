using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace="urn:WebsIFAC/DemandeAnnulationIFAC")]
	public interface DemandeAnnulationIFAC {
		
		[OperationContract]
		List<DemandeAnnulationBO> SelectById(String Token, Int32 pDemandeAnnulationId);
	}
}
