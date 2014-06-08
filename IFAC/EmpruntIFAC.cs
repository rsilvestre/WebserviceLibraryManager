using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebsBO;

namespace WebsIFAC {
	[ServiceContract(Namespace = "urn:WebsIFAC/EmpruntIFAC")]
	public interface EmpruntIFAC {
		[OperationContract]
		List<EmpruntBO> SelectAll(String token);

		[OperationContract]
		EmpruntBO SelectEmpruntById(String token, Int32 pId);

		[OperationContract]
		List<EmpruntBO> SelectEmpruntByClientId(String token, Int32 pClientId);

		[OperationContract]
		EmpruntBO ConvertReservation(String token, Int32 pAdministrateurId, Int32 pReservationId);

		[OperationContract]
		EmpruntBO InsertEmprunt(String token, Int32 pAdministrateurId, Int32 pPersonneId, Int32 pLivreId);

		[OperationContract]
		EmpruntBO InsertRetour(String token, Int32 pAdministrateurId, Int32 pLivreId);

		[OperationContract]
		EmpruntBO InsertAnnul(String token, Int32 pAdministrateurId, Int32 pReservationId);
	}

}
