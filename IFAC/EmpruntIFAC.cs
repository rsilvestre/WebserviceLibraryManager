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
		List<EmpruntBO> SelectAll(String Token);

		[OperationContract]
		EmpruntBO SelectEmpruntById(String Token, int pId);

		[OperationContract]
		EmpruntBO InsertEmpruntFromReservation(String Token, Int32 pAdministrateurId, Int32 pReservationId);

		[OperationContract]
		EmpruntBO InsertEmprunt(String Token, Int32 pAdministrateurId, Int32 pPersonneId, Int32 pLivreId);

		[OperationContract]
		EmpruntBO InsertRetour(String Token, Int32 pAdministrateurId, Int32 pLivreId);

		[OperationContract]
		EmpruntBO InsertAnnul(String Token, Int32 pAdministrateurId, Int32 pLivreId);
	}

}
